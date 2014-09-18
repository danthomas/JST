using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class TrainerScheduleDetail
    {
        public TrainerScheduleDetail(DateTime weekBeginning, List<WorkoutType> workoutTypes, List<WorkoutDay> workoutDays  )
        {
            WeekBeginning = weekBeginning;
            WorkoutTypes = workoutTypes;
            WorkoutDays = workoutDays;
        }


        public DateTime WeekBeginning { get; set; }
        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDay
        {
            public WorkoutDay(DateTime date, string comment)
            {
                Date = date;
                Comment = comment;
                Workouts = new List<Workout>();
            }

            public DateTime Date { get; set; }
            public string Comment { get; set; }
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

        public class WorkoutDate
        {
            public WorkoutDate(int workoutDateId, DateTime date, string comment)
            {
                WorkoutDateId = workoutDateId;
                Date = date;
                Comment = comment;
            }

            public int WorkoutDateId { get; set; }
            public DateTime Date { get; set; }
            public string Comment { get; set; }
        }
    }
}