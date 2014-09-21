﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DTS.AppFramework.Core;
using JST.Business.Models;
using JST.Core;
using JST.DataAccess;

namespace JST.Business
{
    public class AccountBusiness : BusinessBase
    {
        private readonly IAccountDataService _accountDataService;

        public AccountBusiness(IAccountDataService accountDataService, IRoleDataService roleDataService, IExceptionDataService exceptionDataService, ISessionDataService sessionDataService)
            : base(sessionDataService, roleDataService, exceptionDataService)
        {
            _accountDataService = accountDataService;
        }

        public ReturnValue<Session> Login(string accountName, string password)
        {
            using (JstDataContext jstDataContext = new JstDataContext())
            {
                Session session = null;

                Domain.Account account = _accountDataService.SelectByAccountName(jstDataContext, accountName);

                string hash = HashPassword(password);

                if (account != null && account.Password == hash && account.IsActive)
                {
                    Guid sessionId = InsertSession(jstDataContext, account);
                    string[] roles = _roleDataService.SelectForAccountId(jstDataContext, account.AccountId).Select(item => item.Code).ToArray();
                    session = new Session(sessionId, account.DisplayName, roles);
                }

                return new ReturnValue<Session>(session != null, session);
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

        private Guid InsertSession(JstDataContext jstDataContext, Domain.Account account)
        {
            Guid sessionId = Guid.NewGuid();
            Domain.Session session = new Domain.Session(sessionId, account.AccountId, DateTime.Now, "");
            _sessionDataService.Insert(jstDataContext, session);
            return sessionId;
        }

        public ReturnValue<List<Account>> GetAccountList(Guid sessionId)
        {
            return BusinessMethod(sessionId, new[] { "Admin" }, (jstDataContext, s) =>
            {
                List<Account> accounts = _accountDataService.SelectAll(jstDataContext).Select(item => new Account
                {
                    AccountId = item.AccountId,
                    AccountName = item.AccountName,
                    DisplayName = item.DisplayName
                }).ToList();

                return new ReturnValue<List<Account>>(true, accounts);
            }, exception => null);
        }

        public ReturnValue<Account> GetAccountEdit(Guid sessionId, short accountId)
        {
            return BusinessMethod(sessionId, new[] { "Admin" }, (jstDataContext, s) =>
            {
                Domain.Account account = _accountDataService.SelectByAccountId(jstDataContext, accountId);

                return new ReturnValue<Account>(true, new Account
                {
                    AccountId = account.AccountId,
                    AccountName = account.AccountName,
                    DisplayName = account.DisplayName
                });
            }, exception => null);
        }

        public ReturnValue<short> SaveAccount(Guid sessionId, short accountId, string accountName, string displayName)
        {
            return BusinessMethod(sessionId, new[] { "Admin" }, (jstDataContext, s) =>
            {
                Domain.Account account = new Domain.Account(accountId, accountName, displayName, "", "", false, true);

                if (accountId == 0)
                {
                    account.Password = HashPassword("burpee");
                    jstDataContext.OpenTransation();

                    _accountDataService.Insert(jstDataContext, account);

                    _roleDataService.S

                    jstDataContext.Commit();
                }
                else
                {
                    _accountDataService.Update(jstDataContext, account);
                }

                return new ReturnValue<short>(true, account.AccountId);

            }, exception => "Failed to Save Account.");

        }
    }
}
