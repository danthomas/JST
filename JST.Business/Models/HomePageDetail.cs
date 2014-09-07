using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class HomePageDetail
    {
        public HomePageDetail(IEnumerable<WorkoutType> workoutTypes, IEnumerable<Workout> workouts)
        {
            WorkoutTypes = workoutTypes.ToList();
            Workouts = workouts.ToList();
        }

        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<Workout> Workouts { get; set; } 
    }
}