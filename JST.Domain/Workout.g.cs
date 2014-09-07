using System;

namespace JST.Domain
{
    public class Workout
    {
        public Workout(int workoutId, int workoutDateId, byte workoutTypeId, string detail)
        {
            WorkoutId = workoutId;
            WorkoutDateId = workoutDateId;
            WorkoutTypeId = workoutTypeId;
            Detail = detail;
        }
    
        public int WorkoutId { get; set; }
        public int WorkoutDateId { get; set; }
        public byte WorkoutTypeId { get; set; }
        public string Detail { get; set; }
    }
}