using System;

namespace JST.Business.Models
{
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