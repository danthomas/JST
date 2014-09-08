using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class WorkoutDay
    {
        public WorkoutDay(DateTime date)
        {
            Date = date;
            Workouts = new List<Workout>();
        }

        public DateTime Date { get; set; }
        public List<Workout> Workouts { get; set; } 
    }
}