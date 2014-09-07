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
        DataSet SelectForMemberHomeByDate(DateTime date);
    }

    public partial class ResultDataService : IResultDataService
    {
    }
}
