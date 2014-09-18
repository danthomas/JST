using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class SaveTrainerScheduleDetail
    {
        public SaveTrainerScheduleDetail(Guid sessionId, List<WorkoutDay> workoutDays)
        {
            SessionId = sessionId;
            WorkoutDays = workoutDays;
        }


        public Guid SessionId { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDay
        {
            public WorkoutDay()
            {
                Workouts = new List<Workout>();
            }

            public string Comment { get; set; }
            public DateTime Date { get; set; }
            public List<Workout> Workouts { get; set; }
        }

        public class Workout
        {
            public Workout(int workoutId, byte workoutTypeId, string detail, DateTime date)
            {
                WorkoutId = workoutId;
                WorkoutTypeId = workoutTypeId;
                Detail = detail;
                Date = date;
            }

            public int WorkoutId { get; set; }
            public byte WorkoutTypeId { get; set; }
            public string Detail { get; set; }
            public DateTime Date { get; set; }
        }
    }
}