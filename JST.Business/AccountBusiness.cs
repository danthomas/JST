using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JST.Business.Models;
using JST.Core;
using JST.DataAccess;
using JST.Domain;

namespace JST.Business
{
    public class AccountBusiness : BusinessBase
    {
        private readonly AccountDataService _accountDataService;

        public AccountBusiness(AccountDataService accountDataService, RoleDataService roleDataService, SessionDataService sessionDataService)
            : base(sessionDataService, roleDataService)
        {
            _accountDataService = accountDataService;
        }

        public Models.Session Login(string accountName, string password)
        {
            using (JstDataContext jstDataContext = new JstDataContext())
            {
                Models.Session session = null;

                Account account = _accountDataService.SelectByAccountName(jstDataContext, accountName);

                string hash = HashPassword(password);
                
                if (account != null && account.Password == hash && account.IsActive)
                {
                    Guid sessionId = InsertSession(jstDataContext, account);
                    string[] roles = _roleDataService.SelectForAccountId(jstDataContext, account.AccountId).Select(item => item.Code).ToArray();
                    session = new Models.Session(sessionId, account.DisplayName, roles);
                }

                return session;
            }
        }

        public string HashPassword(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes("TeStSaLt");

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 1000);
            var encryptor = SHA512.Create();
            var hash = encryptor.ComputeHash(rfc2898DeriveBytes.GetBytes(16));

            StringBuilder sb = new StringBuilder();

            foreach (byte t in hash)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }

        private Guid InsertSession(JstDataContext jstDataContext, Account account)
        {
            Guid sessionId = Guid.NewGuid();
            Domain.Session session = new Domain.Session(sessionId, account.AccountId, DateTime.Now, "");
            _sessionDataService.Insert(jstDataContext, session);
            return sessionId;
        }
    }
}
