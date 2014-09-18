using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IWorkoutDataService
    {
        void Insert(JstDataContext dataContext, Domain.Workout workout);

        void Update(JstDataContext dataContext, Domain.Workout workout);

        Workout SelectByWorkoutId(JstDataContext dataContext, int workoutId);

        Workout SelectByWorkoutDateIdWorkoutTypeId(JstDataContext dataContext, int workoutDateId, byte workoutTypeId);
    }

    public partial class WorkoutDataService : IWorkoutDataService
    {
        public virtual void Insert(JstDataContext dataContext, Domain.Workout workout)
        {
            workout.WorkoutId = dataContext.ExecuteScalar<int>("Competitors.Workout_Insert", CommandType.StoredProcedure, new Parameter("WorkoutDateId", SqlDbType.Int, workout.WorkoutDateId), new Parameter("WorkoutTypeId", SqlDbType.TinyInt, workout.WorkoutTypeId), new Parameter("Detail", SqlDbType.VarChar, workout.Detail));
        }

        public virtual void Update(JstDataContext dataContext, Domain.Workout workout)
        {
            dataContext.ExecuteNonQuery("Competitors.Workout_Update", CommandType.StoredProcedure, new Parameter("WorkoutId", SqlDbType.Int, workout.WorkoutId), new Parameter("WorkoutDateId", SqlDbType.Int, workout.WorkoutDateId), new Parameter("WorkoutTypeId", SqlDbType.TinyInt, workout.WorkoutTypeId), new Parameter("Detail", SqlDbType.VarChar, workout.Detail));            
        }

        public virtual Workout SelectByWorkoutId(JstDataContext dataContext, int workoutId)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Competitors.Workout_SelectByWorkoutId", CommandType.StoredProcedure, new Parameter("WorkoutId", SqlDbType.Int, workoutId));

            return dataRow == null ? null : new Workout(dataRow.Field<int>("WorkoutId"), dataRow.Field<int>("WorkoutDateId"), dataRow.Field<byte>("WorkoutTypeId"), dataRow.Field<string>("Detail"));
        }

        public virtual Workout SelectByWorkoutDateIdWorkoutTypeId(JstDataContext dataContext, int workoutDateId, byte workoutTypeId)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Competitors.Workout_SelectByWorkoutDateIdWorkoutTypeId", CommandType.StoredProcedure, new Parameter("WorkoutDateId", SqlDbType.Int, workoutDateId), new Parameter("WorkoutTypeId", SqlDbType.TinyInt, workoutTypeId));

            return dataRow == null ? null : new Workout(dataRow.Field<int>("WorkoutId"), dataRow.Field<int>("WorkoutDateId"), dataRow.Field<byte>("WorkoutTypeId"), dataRow.Field<string>("Detail"));
        }
    }
}