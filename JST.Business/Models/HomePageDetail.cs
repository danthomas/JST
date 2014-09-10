using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class HomePageDetail
    {
        public HomePageDetail(DateTime weekBeginning, IEnumerable<WorkoutType> workoutTypes, IEnumerable<WorkoutDate> workoutDates, IEnumerable<Workout> workouts)
        {
            WeekBeginning = weekBeginning;
            WorkoutTypes = workoutTypes.Join(workouts.Select(item => item.WorkoutTypeId).Distinct(), workoutType => workoutType.WorkoutTypeId, workoutTypeId => workoutTypeId, (workoutType, workout) => workoutType).ToList();
            WorkoutDays = new List<WorkoutDay>();

            for (int i = 0; i < 7; ++i)
            {
                DateTime date = weekBeginning.AddDays(i);
                WorkoutDate workoutDate = workoutDates.SingleOrDefault(item => item.Date == date);
                WorkoutDay workoutDay = new WorkoutDay(date, workoutDate == null ? "" : workoutDate.ResultDetail);
                foreach (WorkoutType workoutType in WorkoutTypes)
                {
                    workoutDay.Workouts.Add(workouts.SingleOrDefault(item => item.Date == workoutDay.Date && item.WorkoutTypeId == workoutType.WorkoutTypeId));
                }
                workoutDay.IsRestDay = workoutDay.Workouts.All(item => item == null);
                WorkoutDays.Add(workoutDay);
            }
        }

        public DateTime WeekBeginning { get; set; }
        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }

        public class WorkoutDate
        {
            public WorkoutDate(int workoutDateId, DateTime date, string comment, string resultDetail)
            {
                WorkoutDateId = workoutDateId;
                Date = date;
                Comment = comment;
                ResultDetail = resultDetail;
            }

            public int WorkoutDateId { get; set; }
            public DateTime Date { get; set; }
            public string Comment { get; set; }
            public string ResultDetail { get; set; }
        }

        public class WorkoutDay
        {
            public WorkoutDay(DateTime date, string resultDetail)
            {
                Date = date;
                ResultDetail = resultDetail;
                Workouts = new List<Workout>();
            }

            public DateTime Date { get; set; }
            public string ResultDetail { get; set; }
            public List<Workout> Workouts { get; set; }
            public bool IsRestDay { get; set; }
        }

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
}