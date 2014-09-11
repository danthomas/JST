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
        DataSet SelectForMemberHomeByDate(DateTime date);
    }

    public partial class ResultDataService
    {
        public DataSet SelectForMemberHomeByDate(DateTime date)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataSet("Competitors.Result_SelectForMemberHomeByDate", CommandType.StoredProcedure, new Parameter("Date", SqlDbType.Date, date));
            }
        }
    }
}
