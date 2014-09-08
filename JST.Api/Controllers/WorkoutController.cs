using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTS.AppFramework.Core;
using JST.Business;
using JST.Business.Models;

namespace JST.Api.Controllers
{
    public class WorkoutController : ApiController
    {
        private readonly WorkoutBusiness _workoutBusiness;

        public WorkoutController(WorkoutBusiness workoutBusiness)
        {
            _workoutBusiness = workoutBusiness;
        }
        
        [HttpPost]
        [Route("api/workout/homepagedetail")]
        public ReturnValue<HomePageDetail> GetHomePageDetail([FromBody]DateTime date)
        {
            return new ReturnValue<HomePageDetail>(true, _workoutBusiness.GetHomePageDetail(date));
        }
    }
}
