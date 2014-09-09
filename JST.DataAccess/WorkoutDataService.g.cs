using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public interface IWorkoutDataService
    {
        DataSet SelectMemberHomePageDetail(DateTime date, short accountId);
        DataSet SelectMemberWorkoutDayDetails(DateTime date, short accountId);
        DataSet SelectMemberResultsDetails(DateTime date, short accountId);
    }

    public partial class WorkoutDataService : IWorkoutDataService
    {
    }
}
