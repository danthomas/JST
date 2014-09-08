using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class MemberWorkoutDayDetail
    {
        public MemberWorkoutDayDetail(DateTime date, IEnumerable<Workout> workouts, int workoutDateId, int resultId, string resultDetail)
        {
            Date = date;
            WorkoutDateId = workoutDateId;
            ResultId = resultId;
            ResultDetail = resultDetail;
            Workouts = workouts.ToList();
        }

        public DateTime Date { get; set; }
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