using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using JST.Business;
using JST.Business.Models;
using Microsoft.Office.Interop.Excel;

namespace JST.DataImport
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 
               List<List<List<string>>> workbookData = GetData();

               Stream stream = File.Open(@"C:\Users\Dan\Dropbox\DTS\Clients\JST\Data.dat", FileMode.Create);
               BinaryFormatter bFormatter = new BinaryFormatter();
               bFormatter.Serialize(stream, workbookData);
               stream.Close();
            */
            List<Tuple<string, string>> userNames = GetUserNames();

            Stream stream = File.Open(@"C:\Users\Dan\Dropbox\DTS\Clients\JST\Data.dat", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            List<List<List<string>>> workbookData = (List<List<List<string>>>)bFormatter.Deserialize(stream);

            ProcessData(workbookData, userNames);

        }

        private static void ProcessData(List<List<List<string>>> workbook, List<Tuple<string, string>> userNames)
        {
            List<Competitor> competitors = new List<Competitor>();
            List<WorkoutDate> workoutDates = new List<WorkoutDate>();
            List<Workout> workouts = new List<Workout>();
            List<Result> results = new List<Result>();

            int competitorId = 4;
            int workoutDateId = 1;
            int workoutId = 1;
            int userNameId = 1;

            foreach (List<List<string>> worksheet in workbook)
            {
                if (worksheet.Count > 0)
                {
                    for (int i = 7; i < worksheet[0].Count(); ++i)
                    {
                        string name = worksheet[0][i];

                        if (name != "")
                        {
                            Competitor competitor = competitors.SingleOrDefault(item => item.Name.ToLower() == name.ToLower());

                            if (competitor == null)
                            {
                                Tuple<string, string> username = userNames.SingleOrDefault(item => item.Item1 == name);
                                competitor = new Competitor(competitorId++, name, username == null ? "" : username.Item2);
                                competitors.Add(competitor);
                            }
                        }
                    }


                    foreach (List<string> row in worksheet.Skip(1))
                    {
                        DateTime date;

                        if (DateTime.TryParseExact(row[0], "dd/MM/yyyy 00:00:00", null, DateTimeStyles.None, out date))
                        {
                            WorkoutDate workoutDate = workoutDates.SingleOrDefault(item => item.Date == date);

                            if (workoutDate != null)
                            {
                                throw new Exception();
                            }
                            else
                            {

                                workoutDate = new WorkoutDate(workoutDateId++, date);
                                workoutDates.Add(workoutDate);

                                for (int i = 1; i <= 6; i++)
                                {
                                    if (row[i] != "")
                                    {
                                        workouts.Add(new Workout(workoutId++, workoutDate, i, row[i].Replace("\n", Environment.NewLine)));
                                    }
                                }

                                for (int i = 7; i < row.Count; ++i)
                                {
                                    string name = worksheet[0][i];
                                    string detail = row[i];

                                    if (name != "" && detail != "")
                                    {
                                        Competitor competitor = competitors.Single(item => item.Name.ToLower() == name.ToLower());
                                        Result result = new Result(workoutDate, competitor, detail.Replace("\n", Environment.NewLine));

                                        results.Add(result);
                                    }
                                }
                            }
                        }
                    }


                }
            }
            AccountBusiness accountBusiness = new AccountBusiness(null, null, null, null, null);
            accountBusiness.HashPassword("burpee");


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("set identity_insert Security.Account on");
            stringBuilder.AppendFormat("insert into Security.Account (AccountId, AccountName, DisplayName, Email, [Password], ChangePassword, IsActive) values (1, 'thomasd', 'Dan Thomas', '', '{1}', 0, 1){0}", Environment.NewLine, accountBusiness.HashPassword("hillrun"));
            stringBuilder.AppendFormat("insert into Security.Account (AccountId, AccountName, DisplayName, Email, [Password], ChangePassword, IsActive) values (2, 'fawcetts', 'Steven Fawcett', '', '{1}', 0, 1){0}", Environment.NewLine, accountBusiness.HashPassword("squat"));
            stringBuilder.AppendFormat("insert into Security.Account (AccountId, AccountName, DisplayName, Email, [Password], ChangePassword, IsActive) values (3, 'bulloughj', 'Jonathan Bullough', '', '{1}', 0, 1){0}", Environment.NewLine, accountBusiness.HashPassword("squat"));

            foreach (Competitor competitor in competitors)
            {
                stringBuilder.AppendFormat("insert into Security.Account (AccountId, AccountName, DisplayName, Email, [Password], ChangePassword, IsActive) values ({1}, '{2}', '{3}', '', '{4}', 0, 1){0}",
                    Environment.NewLine,
                    competitor.Id,
                    competitor.Username == "" ? "Account" + userNameId++ : competitor.Username,
                    (competitor.Name).Replace("'", "''"),
                    accountBusiness.HashPassword("burpee"));
            }

            foreach (Tuple<string, string> username in userNames.Skip(1))
            {

                if (new String[] { "thomasd", "fawcetts", "bulloughj" }.Contains(username.Item2.ToLower()))
                {
                    continue;
                }

                
                if (competitors.All(item => item.Username.ToLower() != username.Item2.ToLower()))
                {
                    stringBuilder.AppendFormat("insert into Security.Account (AccountId, AccountName, DisplayName, Email, [Password], ChangePassword, IsActive) values ({1}, '{2}', '{3}', '', '{4}', 0, 1){0}",
                        Environment.NewLine,
                        competitorId++,
                        username.Item2,
                        username.Item1,
                        accountBusiness.HashPassword("burpee"));
                }
            }


            stringBuilder.AppendLine("set identity_insert Security.Account off");

            File.WriteAllText(@"C:\Users\Dan\Documents\Visual Studio 2013\Projects\Solutions\JST.SqlServer\Data\Security.Account.sql", stringBuilder.ToString());


            stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("insert into Security.AccountRole (AccountId, RoleId) values (1, 1){0}", Environment.NewLine);
            stringBuilder.AppendFormat("insert into Security.AccountRole (AccountId, RoleId) values (2, 1){0}", Environment.NewLine);
            stringBuilder.AppendFormat("insert into Security.AccountRole (AccountId, RoleId) values (2, 2){0}", Environment.NewLine);
            stringBuilder.AppendFormat("insert into Security.AccountRole (AccountId, RoleId) values (3, 2){0}", Environment.NewLine);

            foreach (Competitor competitor in competitors)
            {
                stringBuilder.AppendFormat("insert into Security.AccountRole (AccountId, RoleId) values ({1}, 3){0}",
                    Environment.NewLine,
                    competitor.Id);
            }

            File.WriteAllText(@"C:\Users\Dan\Documents\Visual Studio 2013\Projects\Solutions\JST.SqlServer\Data\Security.AccountRole.sql", stringBuilder.ToString());




            stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("set identity_insert Competitors.WorkoutDate on");

            foreach (WorkoutDate workoutDate in workoutDates.Where(item =>
                item.Date != new DateTime(2014, 4, 7)
                && item.Date != new DateTime(2014, 8, 7)
                && item.Date != new DateTime(2014, 8, 14)
                && item.Date != new DateTime(2014, 8, 15)))
            {
                stringBuilder.AppendFormat("insert into Competitors.WorkoutDate (WorkoutDateId, Date, Comment) values ({1}, '{2}', ''){0}",
                    Environment.NewLine,
                    workoutDate.Id,
                    workoutDate.Date.ToString("yyyy-MM-dd"));
            }

            stringBuilder.AppendLine("set identity_insert Competitors.WorkoutDate off");

            File.WriteAllText(@"C:\Users\Dan\Documents\Visual Studio 2013\Projects\Solutions\JST.SqlServer\Data\Competitors.WorkoutDate.sql", stringBuilder.ToString());


            stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("set identity_insert Competitors.Workout on");

            foreach (Workout workout in workouts.Where(item =>
                item.WorkoutDate.Date != new DateTime(2014, 4, 7)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 7)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 14)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 15)))
            {
                if (!String.IsNullOrEmpty(workout.Detail))
                {
                    stringBuilder.AppendFormat("{0}insert into Competitors.Workout (WorkoutId, WorkoutDateId, WorkoutTypeId, Detail) values ({1}, {2}, {3}, '{4}')",
                        Environment.NewLine,
                        workout.Id,
                        workout.WorkoutDate.Id,
                        workout.WorkoutTypeId,
                        workout.Detail.Replace("'", "''"));
                }
            }
            stringBuilder.AppendLine("set identity_insert Competitors.Workout off");

            File.WriteAllText(@"C:\Users\Dan\Documents\Visual Studio 2013\Projects\Solutions\JST.SqlServer\Data\Competitors.Workout.sql", stringBuilder.ToString());

            stringBuilder = new StringBuilder();

            foreach (Result result in results.Where(item =>
                item.WorkoutDate.Date != new DateTime(2014, 4, 7)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 7)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 14)
                && item.WorkoutDate.Date != new DateTime(2014, 8, 15)))
            {
                stringBuilder.AppendFormat("insert into Competitors.Result (WorkoutDateId, AccountId, Detail) values ({1}, {2}, '{3}'){0}",
                    Environment.NewLine,
                    result.WorkoutDate.Id,
                    result.Competitor.Id,
                    result.Detail.Replace("'", "''"));
            }

            File.WriteAllText(@"C:\Users\Dan\Documents\Visual Studio 2013\Projects\Solutions\JST.SqlServer\Data\Competitors.Result.sql", stringBuilder.ToString());

        }



        private static List<Tuple<string, string>> GetUserNames()
        {
            List<Tuple<string, string>> ret = new List<Tuple<string, string>>();

            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(@"C:\Users\Dan\Dropbox\DTS\Clients\JST\Competitors Programme.xlsx");

            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "UserNames")
                {
                    foreach (Range range in worksheet.UsedRange.Rows)
                    {
                        object name = range.Cells[1, 1].Value;
                        object username = range.Cells[1, 2].Value;

                        ret.Add(new Tuple<string, string>(name.ToString(), username.ToString()));
                    }
                }
            }


            return ret;
        }

        private static List<List<List<string>>> GetData()
        {
            List<List<List<string>>> workbookData = new List<List<List<string>>>();

            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(@"C:\Users\Dan\Dropbox\DTS\Clients\JST\Competitors Programme.xlsx");

            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                List<List<string>> worksheetData = new List<List<string>>();
                workbookData.Add(worksheetData);

                foreach (Range range in worksheet.UsedRange.Rows)
                {
                    List<string> rowData = new List<string>();
                    worksheetData.Add(rowData);

                    for (int i = 0; i < range.Columns.Count; i++)
                    {
                        object data = range.Cells[1, i + 1].Value;
                        rowData.Add((data ?? "").ToString());
                    }
                }
            }

            return workbookData;
        }
    }

    internal class WorkoutDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public WorkoutDate(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }

    class Competitor
    {
        public Competitor(int id, string name, string username)
        {
            Id = id;
            Name = name;
            Username = username;
        }

        public string Name { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
    }

    internal class Result
    {
        public WorkoutDate WorkoutDate { get; set; }
        public Competitor Competitor { get; set; }
        public string Detail { get; set; }

        public Result(WorkoutDate workoutDate, Competitor competitor, string detail)
        {
            WorkoutDate = workoutDate;
            Competitor = competitor;
            Detail = detail;
        }
    }

    internal class Workout
    {
        public int Id { get; set; }
        public WorkoutDate WorkoutDate { get; set; }
        public int WorkoutTypeId { get; set; }
        public string Detail { get; set; }

        public Workout(int id, WorkoutDate workoutDate, int workoutTypeId, string detail)
        {
            Id = id;
            WorkoutDate = workoutDate;
            WorkoutTypeId = workoutTypeId;
            Detail = detail;
        }
    }
}
