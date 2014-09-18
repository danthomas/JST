using System;
using System.Collections.Generic;
using System.Linq;
using DTS.AppFramework.Core;
using JST.Core;
using JST.DataAccess;

namespace JST.Business
{
    public abstract class BusinessBase
    {
        protected readonly ISessionDataService _sessionDataService;
        protected readonly IRoleDataService _roleDataService;

        protected BusinessBase(ISessionDataService sessionDataService, IRoleDataService roleDataService)
        {
            _sessionDataService = sessionDataService;
            _roleDataService = roleDataService;
        }

        protected ReturnValue BusinessMethod(Guid sessionId, IEnumerable<string> roleNames, Func<JstDataContext, short, ReturnValue> action, Func<Exception, ReturnValue> exceptionAction)
        {
            short accountId;
            if (!SecurityCheck(sessionId, roleNames, out accountId))
            {
                return new ReturnValue(false, MessageType.Validation, "Access Denied");
            }

            using (JstDataContext jstDataContext = new JstDataContext())
            {
                try
                {
                    return action(jstDataContext, accountId);
                }
                catch (Exception exception)
                {
                    return exceptionAction(exception);
                }
            }
        }

        protected ReturnValue<T> BusinessMethod<T>(Guid sessionId, IEnumerable<string> roleNames, Func<JstDataContext, short, ReturnValue<T>> action, Func<Exception, ReturnValue<T>> exceptionAction)
        {
            short accountId;
            if (!SecurityCheck(sessionId, roleNames, out accountId))
            {
                return new ReturnValue<T>(false, MessageType.Validation, "Access Denied", default(T));
            }

            using (JstDataContext jstDataContext = new JstDataContext())
            {
                try
                {
                    return action(jstDataContext, accountId);
                }
                catch (Exception exception)
                {
                    return exceptionAction(exception);
                }
            }
        }

        private bool SecurityCheck(Guid sessionId, IEnumerable<string> roleNames, out short accountId)
        {
            accountId = 0;

            using (JstDataContext jstDataContext = new JstDataContext())
            {
                Domain.Session session = _sessionDataService.SelectBySessionId(jstDataContext, sessionId);


                if (session == null)
                {
                    return false;
                }

                accountId = session.AccountId;

                if (roleNames != null)
                {
                    if (!roleNames.Join(_roleDataService.SelectForAccountId(jstDataContext, session.AccountId), left => left, right => right.Code, (left, right) => left).Any())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}