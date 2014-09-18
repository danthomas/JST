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
        protected readonly IExceptionDataService _exceptionDataService;

        protected BusinessBase(ISessionDataService sessionDataService, IRoleDataService roleDataService, IExceptionDataService exceptionDataService)
        {
            _sessionDataService = sessionDataService;
            _roleDataService = roleDataService;
            _exceptionDataService = exceptionDataService;
        }

        protected ReturnValue BusinessMethod(Guid sessionId, IEnumerable<string> roleNames, Func<JstDataContext, short, ReturnValue> action, Func<Exception, string> exceptionAction)
        {
            short? accountId;
            if (!SecurityCheck(sessionId, roleNames, out accountId))
            {
                return new ReturnValue(false, MessageType.Validation, "Access Denied");
            }

            using (JstDataContext jstDataContext = new JstDataContext())
            {
                try
                {
                    return action(jstDataContext, accountId.GetValueOrDefault());
                }
                catch (Exception exception)
                {
                    LogException(exception);
                    return new ReturnValue(false, MessageType.Error, exceptionAction(exception));
                }
            }
        }

        private void LogException(Exception exception)
        {
            try
            {
                _exceptionDataService.Insert(new JstDataContext(), new Domain.Exception(0, exception.Message, exception.StackTrace, DateTime.Now));
            }
            catch
            {
            }
        }

        protected ReturnValue<T> BusinessMethod<T>(Guid sessionId, IEnumerable<string> roleNames, Func<JstDataContext, short, ReturnValue<T>> action, Func<Exception, string> exceptionAction)
        {
            short? accountId;
            if (!SecurityCheck(sessionId, roleNames, out accountId))
            {
                return new ReturnValue<T>(false, MessageType.Validation, "Access Denied", default(T));
            }

            using (JstDataContext jstDataContext = new JstDataContext())
            {
                try
                {
                    return action(jstDataContext, accountId.GetValueOrDefault());
                }
                catch (Exception exception)
                {
                    LogException(exception);
                    return new ReturnValue<T>(false, MessageType.Error, exceptionAction(exception), default(T));
                }
            }
        }

        private bool SecurityCheck(Guid sessionId, IEnumerable<string> roleNames, out short? accountId)
        {
            accountId = null;

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