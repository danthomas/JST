using System;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;

namespace JST.DataAccess
{
    public partial interface IWorkoutDataService
    {
        DataSet SelectMemberHomePageDetail(JstDataContext dataContext, DateTime date, short accountId);
        DataSet SelectMemberWorkoutDayDetails(JstDataContext dataContext, DateTime date, string direction, short accountId);
        DataSet SelectMemberResultsDetails(JstDataContext dataContext, DateTime date, string direction, short accountId);
        DataSet SelectCompetitorMyResultsDetails(JstDataContext dataContext, short accountId);
        DataSet SelectTrainerScheduleDetail(JstDataContext dataContext, DateTime date);
        void Delete(JstDataContext dataContext, int workoutId);
    }

    public partial class WorkoutDataService
    {
        public DataSet SelectTrainerScheduleDetail(JstDataContext dataContext, DateTime date)
        {
            return dataContext.ExecuteDataSet("Competitors.Workout_SelectTrainerScheduleDetail", CommandType.StoredProcedure,
                new Parameter("date", SqlDbType.Date, date));
        }

        public void Delete(JstDataContext dataContext, int workoutId)
        {
            dataContext.ExecuteNonQuery("Competitors.Workout_Delete", CommandType.StoredProcedure,
                new Parameter("WorkoutId", SqlDbType.Int, workoutId));
        }

        public DataSet SelectMemberHomePageDetail(JstDataContext dataContext, DateTime date, short accountId)
        {
            return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberHomePageDetail", CommandType.StoredProcedure,
                new Parameter("date", SqlDbType.Date, date),
                new Parameter("accountId", SqlDbType.SmallInt, accountId));
        }

        public DataSet SelectMemberWorkoutDayDetails(JstDataContext dataContext, DateTime date, string direction, short accountId)
        {
            return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberWorkoutDayDetail", CommandType.StoredProcedure,
                new Parameter("date", SqlDbType.Date, date),
                new Parameter("direction", SqlDbType.VarChar, direction),
                new Parameter("accountId", SqlDbType.SmallInt, accountId));
        }

        public DataSet SelectMemberResultsDetails(JstDataContext dataContext, DateTime date, string direction, short accountId)
        {
            return dataContext.ExecuteDataSet("Competitors.Workout_SelectMemberResultsDetail", CommandType.StoredProcedure,
                new Parameter("date", SqlDbType.Date, date),
                new Parameter("direction", SqlDbType.VarChar, direction),
                new Parameter("accountId", SqlDbType.SmallInt, accountId));
        }

        public DataSet SelectCompetitorMyResultsDetails(JstDataContext dataContext, short accountId)
        {
            return dataContext.ExecuteDataSet("Competitors.Workout_SelectCompetitorMyResultsDetail", CommandType.StoredProcedure,
                new Parameter("accountId", SqlDbType.SmallInt, accountId));
        }
    }
}
