using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JST.Admin
{
    public class BackupDatabase
    {
        public void Execute()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "mssql2012.aspnethosting.co.uk,14330",
                InitialCatalog = "danthoma_JST_Prod",
                UserID = "danthoma_jst",
                Password = "T0xygene"
            };
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(String.Format(@"BACKUP DATABASE [danthoma_JST_Prod]
TO  DISK = N'D:\HostingBackups\MSSQL\danthoma_JST_Prod_backup_{0:yyyyMMdd_HHmm}.bak'
WITH NOFORMAT, NOINIT, NAME = N'danthoma_JST_Prod-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", DateTime.Now), sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
