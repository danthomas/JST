namespace JST.Business.Models
{
    public class Workout
    {
        public Workout(int workoutId, byte workoutTypeId, string detail)
        {
            WorkoutId = workoutId;
            WorkoutTypeId = workoutTypeId;
            Detail = detail;
        }

        public int WorkoutId { get; set; }
        public byte WorkoutTypeId { get; set; }
        public string Detail { get; set; }
    }
}