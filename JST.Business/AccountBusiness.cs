using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JST.Business.Models;
using JST.DataAccess;
using JST.Domain;

namespace JST.Business
{
    public class AccountBusiness
    {
        private readonly AccountDataService _accountDataService;
        private readonly AccountTypeDataService _accountTypeDataService;
        private readonly SessionDataService _sessionDataService;

        public AccountBusiness(AccountDataService accountDataService, AccountTypeDataService accountTypeDataService, SessionDataService sessionDataService)
        {
            _accountDataService = accountDataService;
            _accountTypeDataService = accountTypeDataService;
            _sessionDataService = sessionDataService;
        }

        public Models.Session Login(string accountName, string password)
        {
            Models.Session session = null;

            Account account = _accountDataService.SelectByAccountName(accountName);

            if (account != null && account.Password == password)
            {
                AccountType accountType = _accountTypeDataService.SelectByAccountTypeId(account.AccountTypeId);
                Guid sessionId = InsertSession(account);
                session = new Models.Session(sessionId, account.DisplayName, accountType.Code);
            }

            return session;
        }

        private Guid InsertSession(Account account)
        {
            Guid sessionId = Guid.NewGuid();
            Domain.Session session = new Domain.Session(sessionId, account.AccountId, DateTime.Now);
            _sessionDataService.Insert(session);
            return sessionId;
        }
    }
}
