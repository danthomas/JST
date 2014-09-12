using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class CompetitorMyResultsDetail
    {
        public CompetitorMyResultsDetail(List<WorkoutDay> workoutDays)
        {
            WorkoutDays = workoutDays;
        }

        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDay
        {
            public WorkoutDay()
            {
                Workouts = new List<Workout>();
            }

            public int WorkoutDateId { get; set; }
            public DateTime Date { get; set; }
            public string ResultDetail { get; set; }
            public List<Workout> Workouts { get; set; }

            public WorkoutDay( int workoutDateId, DateTime date, string resultDetail)
            {
                WorkoutDateId = workoutDateId;
                Date = date;
                ResultDetail = resultDetail;
            }
        }

        public class Workout
        {
            public Workout(string workoutDetail)
            {
                WorkoutDetail = workoutDetail;
            }

            public string WorkoutDetail { get; set; }
        }
    }
}