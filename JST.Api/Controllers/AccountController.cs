using System;
using System.Collections.Generic;
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
            return _accountBusiness.Login(credentials.AccountName, credentials.Password);
        }

        [HttpPost]
        [Route("api/account/getAccounts")]
        public ReturnValue<List<Account>> GetAccounts([FromBody] GetAccountsDetails getAccountsDetails)
        {
            return _accountBusiness.GetAccounts(getAccountsDetails.SessionId);
        }
        
        public class Credentials
        {
            public string AccountName { get; set; }
            public string Password { get; set; }
        }

        public class GetAccountsDetails
        {
            public Guid SessionId { get; set; }
        }

    }

}
