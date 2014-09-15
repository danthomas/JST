using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class CompetitorMyResultsDetail
    {
        public CompetitorMyResultsDetail(List<WorkoutType> workoutTypes, List<WorkoutDay> workoutDays)
        {
            WorkoutTypes = workoutTypes;
            WorkoutDays = workoutDays;
        }

        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDay
        {
            public WorkoutDay( int workoutDateId, DateTime date, string resultDetail)
            {
                WorkoutDateId = workoutDateId;
                Date = date;
                ResultDetail = resultDetail;
                Workouts = new List<Workout>();
            }

            public int WorkoutDateId { get; set; }
            public DateTime Date { get; set; }
            public string ResultDetail { get; set; }
            public List<Workout> Workouts { get; set; }
        }

        public class Workout
        {
            public Workout(string workoutDetail)
            {
                WorkoutDetail = workoutDetail;
            }

            public string WorkoutDetail { get; set; }
        }

        public class WorkoutType
        {
            public byte WorkoutTypeId { get; set; }
            public string Name { get; set; }

            public WorkoutType(byte workoutTypeId, string name)
            {
                WorkoutTypeId = workoutTypeId;
                Name = name;
            }
        }
    }
}