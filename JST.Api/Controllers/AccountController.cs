using System;
using System.Web.Http;
using JST.Business;
using DTS.AppFramework.Core;
using JST.Business.Models;

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
            Session session = _accountBusiness.Login(credentials.AccountName, credentials.Password);

            return new ReturnValue<Session>(session != null, session);
        }


        public class Credentials
        {
            public string AccountName { get; set; }
            public string Password { get; set; }
        }

    }
}
