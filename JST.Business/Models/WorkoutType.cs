namespace JST.Business.Models
{
    public class WorkoutType
    {
        public WorkoutType(byte workoutTypeId, string name)
        {
            WorkoutTypeId = workoutTypeId;
            Name = name;
        }

        public byte WorkoutTypeId { get; set; }
        public string Name { get; set; }
    }
}