using System;

namespace JST.Domain
{
    public class WorkoutType
    {
        public WorkoutType(byte workoutTypeId, string name, byte sortOrder)
        {
            WorkoutTypeId = workoutTypeId;
            Name = name;
            SortOrder = sortOrder;
        }
    
        public byte WorkoutTypeId { get; set; }
        public string Name { get; set; }
        public byte SortOrder { get; set; }
    }
}