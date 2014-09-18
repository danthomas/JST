using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IWorkoutDateDataService
    {
        void Insert(JstDataContext dataContext, WorkoutDate workoutDate);

        void Update(JstDataContext dataContext, WorkoutDate workoutDate);

        WorkoutDate SelectByDate(JstDataContext dataContext, DateTime date);
    }

    public partial class WorkoutDateDataService : IWorkoutDateDataService
    {
        public virtual void Insert(JstDataContext dataContext, WorkoutDate workoutDate)
        {
            workoutDate.WorkoutDateId = dataContext.ExecuteScalar<int>("Competitors.WorkoutDate_Insert", CommandType.StoredProcedure, new Parameter("Date", SqlDbType.Date, workoutDate.Date), new Parameter("Comment", SqlDbType.VarChar, workoutDate.Comment));
        }

        public virtual void Update(JstDataContext dataContext, WorkoutDate workoutDate)
        {
            dataContext.ExecuteNonQuery("Competitors.WorkoutDate_Update", CommandType.StoredProcedure, new Parameter("WorkoutDateId", SqlDbType.Int, workoutDate.WorkoutDateId), new Parameter("Date", SqlDbType.Date, workoutDate.Date), new Parameter("Comment", SqlDbType.VarChar, workoutDate.Comment));            
        }

        public virtual WorkoutDate SelectByDate(JstDataContext dataContext, DateTime date)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Competitors.WorkoutDate_SelectByDate", CommandType.StoredProcedure, new Parameter("Date", SqlDbType.Date, date));

            return dataRow == null ? null : new WorkoutDate(dataRow.Field<int>("WorkoutDateId"), dataRow.Field<DateTime>("Date"), dataRow.Field<string>("Comment"));
        }
    }
}