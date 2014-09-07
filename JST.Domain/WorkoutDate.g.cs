using System;

namespace JST.Domain
{
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