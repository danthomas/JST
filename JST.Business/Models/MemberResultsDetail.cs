using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class MemberResultsDetail
    {
        public MemberResultsDetail(DateTime date, IEnumerable<Workout> workouts, IEnumerable<Result> results)
        {
            Date = date;
            Workouts = workouts.ToList();
            Results = results.ToList();
        }

        public List<Workout> Workouts { get; set; }

        public List<Result> Results { get; set; }

        public DateTime Date { get; set; }

        public class Result
        {
            public Result(int resultId, bool isCurrentAccount, string accountDisplayName, string resultDetail)
            {
                ResultId = resultId;
                IsCurrentAccount = isCurrentAccount;
                AccountDisplayName = accountDisplayName;
                ResultDetail = resultDetail;
            }

            public int ResultId { get; set; }
            public bool IsCurrentAccount { get; set; }
            public string AccountDisplayName { get; set; }
            public string ResultDetail { get; set; }
        }

        public class Workout
        {
            public Workout(int workoutId, string workoutTypeName, string workoutDetail)
            {
                WorkoutId = workoutId;
                WorkoutTypeName = workoutTypeName;
                WorkoutDetail = workoutDetail;
            }

            public int WorkoutId { get; set; }
            public string WorkoutTypeName { get; set; }
            public string WorkoutDetail { get; set; }
        }
    }
}
