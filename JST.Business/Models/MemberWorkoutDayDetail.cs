using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class MemberWorkoutDayDetail
    {
        public MemberWorkoutDayDetail(DateTime date, string comment, IEnumerable<Workout> workouts, int workoutDateId, int resultId, string resultDetail)
        {
            Date = date;
            Comment = comment;
            WorkoutDateId = workoutDateId;
            ResultId = resultId;
            ResultDetail = resultDetail;
            Workouts = workouts.ToList();
        }

        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int WorkoutDateId { get; set; }
        public int ResultId { get; set; }
        public string ResultDetail { get; set; }
        public List<Workout> Workouts { get; set; }

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