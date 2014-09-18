using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IResultDataService
    {
        DataSet SelectForMemberHomeByDate(JstDataContext dataContext, DateTime date);

        void Delete(JstDataContext dataContext, int resultId);
    }

    public partial class ResultDataService
    {
        public DataSet SelectForMemberHomeByDate(JstDataContext dataContext, DateTime date)
        {
            return dataContext.ExecuteDataSet("Competitors.Result_SelectForMemberHomeByDate", CommandType.StoredProcedure, new Parameter("Date", SqlDbType.Date, date));
        }

        public void Delete(JstDataContext dataContext, int resultId)
        {
            dataContext.ExecuteNonQuery("Competitors.Result_Delete", CommandType.StoredProcedure, new Parameter("ResultId", SqlDbType.Int, resultId));
        }
    }
}
