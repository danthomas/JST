using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IExceptionDataService
    {
        void Insert(JstDataContext dataContext, Domain.Exception exception);

    }

    public partial class ExceptionDataService : IExceptionDataService
    {
        public virtual void Insert(JstDataContext dataContext, Domain.Exception exception)
        {
            exception.ExceptionId = dataContext.ExecuteScalar<int>("Logging.Exception_Insert", CommandType.StoredProcedure, new Parameter("Message", SqlDbType.VarChar, exception.Message), new Parameter("StackTrace", SqlDbType.VarChar, exception.StackTrace), new Parameter("DateTime", SqlDbType.DateTime, exception.DateTime));
        }

    }
}