using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JST.Business;
using JST.Business.Models;

namespace JST.Api.Controllers
{
    public class ResultController : ApiController
    {
        private ResultBusiness _resultBusiness;

        public ResultController(ResultBusiness resultBusiness)
        {
            _resultBusiness = resultBusiness;
        }

        [Route("api/workout/all")]
        public IEnumerable<ResultListItem> Get()
        {
            return null;
        }
    }
}
