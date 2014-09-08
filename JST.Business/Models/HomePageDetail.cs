using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class HomePageDetail
    {
        public HomePageDetail(DateTime weekBeginning, IEnumerable<WorkoutType> workoutTypes, IEnumerable<Workout> workouts)
        {
            WeekBeginning = weekBeginning;
            WorkoutTypes = workoutTypes.ToList();
            WorkoutDays = new List<WorkoutDay>();

            for (int i = 0; i < 7; ++i)
            {
                WorkoutDay workoutDay = new WorkoutDay(weekBeginning.AddDays(i));
                foreach (WorkoutType workoutType in WorkoutTypes)
                {
                    workoutDay.Workouts.Add(workouts.SingleOrDefault(item => item.Date == workoutDay.Date && item.WorkoutTypeId == workoutType.WorkoutTypeId));
                }
                WorkoutDays.Add(workoutDay);
            }
        }

        public DateTime WeekBeginning { get; set; }
        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }
    }
}