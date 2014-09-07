using System;

namespace JST.Domain
{
    public class Result
    {
        public Result(int resultId, int workoutDateId, short accountId, string detail)
        {
            ResultId = resultId;
            WorkoutDateId = workoutDateId;
            AccountId = accountId;
            Detail = detail;
        }
    
        public int ResultId { get; set; }
        public int WorkoutDateId { get; set; }
        public short AccountId { get; set; }
        public string Detail { get; set; }
    }
}