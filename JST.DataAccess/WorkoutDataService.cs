using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.AppFramework.Core;
using JST.Core;

namespace JST.DataAccess
{
    public partial class WorkoutDataService
    {
        public DataSet SelectHomePageDetails(DateTime date)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataSet("Competitors.Workout_SelectHomePageDetails", CommandType.StoredProcedure, new Parameter("date", SqlDbType.Date, date));
            }
        }
    }
}
