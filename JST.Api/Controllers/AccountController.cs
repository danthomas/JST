using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using JST.Business;
using DTS.AppFramework.Core;
using JST.Business.Models;
using JST.Core;

namespace JST.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly AccountBusiness _accountBusiness;

        public AccountController(AccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPost]
        [Route("api/account/login")]
        public ReturnValue Login([FromBody]Credentials credentials)
        {

           string s = HttpContext.Current.Request.UserAgent;
            return _accountBusiness.Login(credentials.AccountName, credentials.Password);
        }

        [HttpPost]
        [Route("api/account/getAccountList")]
        public ReturnValue<List<Account>> GetAccountList([FromBody] GetAccountListArgs getAccountListArgs)
        {
            return _accountBusiness.GetAccountList(getAccountListArgs.SessionId);
        }

        [HttpPost]
        [Route("api/account/getAccountEdit")]
        public ReturnValue<Account> GetAccountEdit([FromBody] GetAccountEditArgs getAccountEditArgs)
        {
            return _accountBusiness.GetAccountEdit(getAccountEditArgs.SessionId, getAccountEditArgs.AccountId);
        }

        [HttpPost]
        [Route("api/account/saveAccount")]
        public ReturnValue<short> SaveAccount([FromBody] SaveAccountArgs saveAccountArgs)
        {
            return _accountBusiness.SaveAccount(saveAccountArgs.SessionId, saveAccountArgs.AccountId, saveAccountArgs.AccountName, saveAccountArgs.DisplayName);
        }
        
        public class Credentials
        {
            public string AccountName { get; set; }
            public string Password { get; set; }
        }

        public class GetAccountListArgs
        {
            public Guid SessionId { get; set; }
        }

        public class GetAccountEditArgs
        {
            public Guid SessionId { get; set; }
            public short AccountId { get; set; }
        }

        public class SaveAccountArgs
        {
            public Guid SessionId { get; set; }
            public short AccountId { get; set; }
            public string AccountName { get; set; }
            public string DisplayName { get; set; }
        }
    }

}
