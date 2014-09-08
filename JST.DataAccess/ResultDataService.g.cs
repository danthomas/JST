using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public interface IResultDataService
    {
        void Insert(Result result);

        void Update(Result result);

        Result SelectByResultId(int resultId);

        DataSet SelectForMemberHomeByDate(DateTime date);
    }

    public partial class ResultDataService : IResultDataService
    {
        public virtual void Insert(Result result)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                result.ResultId = dataContext.ExecuteScalar<int>("Competitors.Result_Insert", CommandType.StoredProcedure, new Parameter("WorkoutDateId", SqlDbType.Int, result.WorkoutDateId), new Parameter("AccountId", SqlDbType.SmallInt, result.AccountId), new Parameter("Detail", SqlDbType.VarChar, result.Detail));
            }
        }

        public virtual void Update(Result result)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                dataContext.ExecuteNonQuery("Competitors.Result_Update", CommandType.StoredProcedure, new Parameter("ResultId", SqlDbType.Int, result.ResultId), new Parameter("WorkoutDateId", SqlDbType.Int, result.WorkoutDateId), new Parameter("AccountId", SqlDbType.SmallInt, result.AccountId), new Parameter("Detail", SqlDbType.VarChar, result.Detail));
            }
        }
        public virtual Result SelectByResultId(int resultId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Competitors.Result_SelectByResultId", CommandType.StoredProcedure, new Parameter("ResultId", SqlDbType.Int, resultId));

                return dataRow == null ? null : new Result(dataRow.Field<int>("ResultId"), dataRow.Field<int>("WorkoutDateId"), dataRow.Field<short>("AccountId"), dataRow.Field<string>("Detail"));
            }
        }
    }
}
