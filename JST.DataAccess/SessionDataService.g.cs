using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public interface ISessionDataService
    {
        void Insert(Session session);

        Session SelectBySessionId(Guid sessionId);
    }

    public partial class SessionDataService : ISessionDataService
    {
        public virtual void Insert(Session session)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                dataContext.ExecuteNonQuery("Security.Session_Insert", CommandType.StoredProcedure, new Parameter("SessionId", SqlDbType.UniqueIdentifier, session.SessionId), new Parameter("AccountId", SqlDbType.SmallInt, session.AccountId), new Parameter("StartDateTime", SqlDbType.DateTime, session.StartDateTime));
            }
        }

        public virtual Session SelectBySessionId(Guid sessionId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Security.Session_SelectBySessionId", CommandType.StoredProcedure, new Parameter("SessionId", SqlDbType.UniqueIdentifier, sessionId));

                return dataRow == null ? null : new Session(dataRow.Field<Guid>("SessionId"), dataRow.Field<short>("AccountId"), dataRow.Field<DateTime>("StartDateTime"));
            }
        }
    }
}
