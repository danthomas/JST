using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JST.Admin
{
    public class SendEmail
    {
        public void Execute(string from, string password, string to, string subject, string bodyFormat, params object[] args)
        {
            SmtpClient smtpClient = new SmtpClient("mail.dtsss.net", 25);
            smtpClient.Credentials = new System.Net.NetworkCredential(from, password);
            
            smtpClient.Send(from, to, subject,
                String.Format(bodyFormat, args));
        }
    }
}
