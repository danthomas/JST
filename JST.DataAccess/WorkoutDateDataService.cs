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
        void Tidy(JstDataContext dataContext);
    }

    public partial class WorkoutDateDataService : IWorkoutDateDataService
    {
        public void Tidy(JstDataContext dataContext)
        {
            dataContext.ExecuteNonQuery("Competitors.WorkoutDate_Tidy", CommandType.StoredProcedure);
        }
    }
}
