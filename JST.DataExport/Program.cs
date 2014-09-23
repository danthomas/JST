using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JST.DataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Jst"].ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(@"
select a.DisplayName, r.Detail, wd.Date
from security.Account a
join Competitors.Result r on a.AccountId = r.AccountId
join Competitors.WorkoutDate wd on r.WorkoutDateId = wd.WorkoutDateId
where r.ResultId >= 936
", connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    
                    XDocument xDocument = new XDocument();
                    XElement root = new XElement("results");
                    xDocument.Add(root);

                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        root.Add(new XElement("result",
                            new XAttribute("DisplayName", dataRow.Field<string>("DisplayName")),
                            new XAttribute("Detail", dataRow.Field<string>("Detail")),
                            new XAttribute("Date", dataRow.Field<DateTime>("Date"))));
                    }

                    xDocument.Save(string.Format(@"C:\Users\Dan\Dropbox\DTS\Clients\JST\Results{0:yyyyMMddhhmm}.xml", DateTime.Now));
                }
            }

        }
    }
}
