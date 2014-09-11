using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class CompetitorMyResultsDetail
    {
        public CompetitorMyResultsDetail(IEnumerable<WorkoutDay> results)
        {
            WorkoutDays = results.ToList();
        }

        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDay
        {
            public int WorkoutDateId { get; set; }
            public DateTime Date { get; set; }
            public string ResultDetail { get; set; }

            public WorkoutDay( int workoutDateId, DateTime date, string resultDetail)
            {
                WorkoutDateId = workoutDateId;
                Date = date;
                ResultDetail = resultDetail;
            }
        }
    }
}