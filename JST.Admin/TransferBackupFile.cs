using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace JST.Admin
{
    public class TransferBackupFile
    {
        private readonly SendEmail _sendEmail;

        public TransferBackupFile(SendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public void Execute()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "ftp.dan-thomas.net",
                UserName = "danthoma",
                Password = "T0xyg3n3!"
            };

            Session session = new Session { DisableVersionCheck = true };

            try
            {
                session.Open(sessionOptions);

                const string remoteDirectoryPath = @"/danthoma/backups/";
                const string localDirectoryPath = @"C:\Users\Dan\Dropbox\DTS\Clients\JST\Backups\";

                RemoteDirectoryInfo remoteDirectoryInfo = session.ListDirectory(remoteDirectoryPath);

                Dictionary<string, bool> transferResults = new Dictionary<string, bool>();

                foreach (RemoteFileInfo remoteFileInfo in remoteDirectoryInfo.Files)
                {
                    if (File.Exists(Path.Combine(localDirectoryPath, remoteFileInfo.Name)))
                    {
                        continue;
                    }

                    if (remoteFileInfo.Name.StartsWith(@"danthoma_JST_Prod_") && remoteFileInfo.Name.EndsWith(@".zip"))
                    {
                        string fileNameDate = remoteFileInfo.Name.Substring(18, 8);
                        DateTime date;

                        if (DateTime.TryParseExact(fileNameDate, "yyyyMMdd", null, DateTimeStyles.None, out date))
                        {
                            if (date.AddDays(7) < DateTime.Today)
                            {

                            }

                            TransferOptions transferOptions = new TransferOptions
                            {
                                TransferMode = TransferMode.Binary
                            };

                            string remotePath = String.Format(@"{0}{1}", remoteDirectoryPath, remoteFileInfo.Name);
                            string localPath = String.Format(@"{0}{1}", localDirectoryPath, remoteFileInfo.Name);

                            TransferOperationResult transferResult = session.GetFiles(remotePath, localPath, false, transferOptions);

                            transferResult.Check();

                            transferResults.Add(remoteFileInfo.Name, transferResult.IsSuccess);
                        }
                        else
                        {

                        }
                    }
                }

                string subject = "No Backup files found to transfer";
                string body = "Backup file transfer.";

                if (transferResults.Any(item => item.Value))
                {
                    subject = "Backup file transfer successful.";

                    body = String.Format("{0}Successfully transferred files:{0}{0}{1}", Environment.NewLine, transferResults.Where(item => item.Value).Select(item => item.Key).Aggregate((a, b) => a + Environment.NewLine + b));
                }

                if (transferResults.Any(item => !item.Value))
                {
                    subject = "Backup file transfer failed.";

                    body += String.Format("{0}Successfully transferred files:{0}{0}{1}", Environment.NewLine, transferResults.Where(item => !item.Value).Select(item => item.Key).Aggregate((a, b) => a + Environment.NewLine + b));
                }

                _sendEmail.Execute("jst@dtsss.net", "B0xjump!", "danthomas000@gmail.com", subject, body);
            }
            catch (Exception e)
            {
                _sendEmail.Execute("jst@dtsss.net", "B0xjump!", "danthomas000@gmail.com", "Backup file transfer failed", e.Message);
            }
        }
    }
}
