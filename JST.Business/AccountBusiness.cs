using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private readonly RoleDataService _roleDataService;
        private readonly SessionDataService _sessionDataService;

        public AccountBusiness(AccountDataService accountDataService, RoleDataService roleDataService, SessionDataService sessionDataService)
        {
            _accountDataService = accountDataService;
            _roleDataService = roleDataService;
            _sessionDataService = sessionDataService;
        }

        public Models.Session Login(string accountName, string password)
        {
            Models.Session session = null;

            Account account = _accountDataService.SelectByAccountName(accountName);

            string hash = HashPassword(password);


            if (account != null && account.Password == hash/* && account.IsActive*/)
            {
                Guid sessionId = InsertSession(account);
                string[] roles = _roleDataService.SelectForAccountId(account.AccountId).Select(item => item.Code).ToArray();
                session = new Models.Session(sessionId, account.DisplayName, roles);
            }

            return session;
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

        private Guid InsertSession(Account account)
        {
            Guid sessionId = Guid.NewGuid();
            Domain.Session session = new Domain.Session(sessionId, account.AccountId, DateTime.Now, "");
            _sessionDataService.Insert(session);
            return sessionId;
        }
    }
}
