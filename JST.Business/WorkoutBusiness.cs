using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using JST.Business.Models;
using JST.DataAccess;

namespace JST.Business
{
    public class WorkoutBusiness
    {
        private readonly IWorkoutDataService _workoutDataService;

        public WorkoutBusiness(IWorkoutDataService workoutDataService)
        {
            _workoutDataService = workoutDataService;
        }

        public HomePageDetail GetHomePageDetail(DateTime date)
        {
            DataSet dataSet = _workoutDataService.SelectHomePageDetails(date);
            HomePageDetail homePageDetail = new HomePageDetail(
                dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new WorkoutType(item.Field<byte>("WorkoutTypeId"), item.Field<string>("Name"))),
                dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new Workout(item.Field<int>("WorkoutId"), item.Field<byte>("WorkoutTypeId"), item.Field<string>("Detail")))
                );


            return homePageDetail;
        }

        public IEnumerable<WorkoutDay> GetByWeek(DateTime day)
        {
            return null;// _workoutDataService.GetByWeek(day);
        }
    }
}
