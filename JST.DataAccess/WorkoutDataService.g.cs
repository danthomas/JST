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
        DataSet SelectHomePageDetails(DateTime date);
    }

    public partial class WorkoutDataService : IWorkoutDataService
    {
    }
}
