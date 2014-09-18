using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface ISessionDataService
    {
        void Insert(JstDataContext dataContext, Domain.Session session);

        Session SelectBySessionId(JstDataContext dataContext, Guid sessionId);
    }

    public partial class SessionDataService : ISessionDataService
    {
        public virtual void Insert(JstDataContext dataContext, Domain.Session session)
        {
            dataContext.ExecuteNonQuery("Security.Session_Insert", CommandType.StoredProcedure, new Parameter("SessionId", SqlDbType.UniqueIdentifier, session.SessionId), new Parameter("AccountId", SqlDbType.SmallInt, session.AccountId), new Parameter("StartDateTime", SqlDbType.DateTime, session.StartDateTime), new Parameter("Client", SqlDbType.VarChar, session.Client));
        }

        public virtual Session SelectBySessionId(JstDataContext dataContext, Guid sessionId)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Security.Session_SelectBySessionId", CommandType.StoredProcedure, new Parameter("SessionId", SqlDbType.UniqueIdentifier, sessionId));

            return dataRow == null ? null : new Session(dataRow.Field<Guid>("SessionId"), dataRow.Field<short>("AccountId"), dataRow.Field<DateTime>("StartDateTime"), dataRow.Field<string>("Client"));
        }
    }
}