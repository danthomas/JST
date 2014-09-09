using System;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;

namespace JST.DataAccess
{
    public partial class WorkoutDataService
    {
        public DataSet SelectMemberHomePageDetail(DateTime date, short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberHomePageDetail", CommandType.StoredProcedure, new Parameter("date", SqlDbType.Date, date), new Parameter("accountId", SqlDbType.SmallInt, accountId));
            }
        }
        public DataSet SelectMemberWorkoutDayDetails(DateTime date, short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberWorkoutDayDetail", CommandType.StoredProcedure, new Parameter("date", SqlDbType.Date, date), new Parameter("accountId", SqlDbType.SmallInt, accountId));
            }
        }

        public DataSet SelectMemberResultsDetails(DateTime date, short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberResultsDetail", CommandType.StoredProcedure, new Parameter("date", SqlDbType.Date, date), new Parameter("accountId", SqlDbType.SmallInt, accountId));
            }
            
        }
    }
}
