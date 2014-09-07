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
    public class WorkoutController : ApiController
    {
        private readonly WorkoutBusiness _workoutBusiness;

        public WorkoutController(WorkoutBusiness workoutBusiness)
        {
            _workoutBusiness = workoutBusiness;
        }

        [HttpPost]
        [Route("api/workout/test")]
        public DateTime Test([FromBody]DateTime date)
        {
            return date.AddMonths(5);
        }
        
        [HttpPost]
        [Route("api/workout/all")]
        public IEnumerable<WorkoutDay> Get()
        {
            return new WorkoutDay[] { new WorkoutDay { Date = new DateTime(2014, 10, 1) } };
        }

        [HttpPost]
        [Route("api/workout/byweek")]
        public IEnumerable<WorkoutDay> GetByWeek([FromBody]DateTime date)
        {
            return null; //return _workoutDataService.
        }
        
        [HttpPost]
        [Route("api/workout/homepagedetail")]
        public HomePageDetail GetHomePageDetail([FromBody]DateTime date)
        {
            return _workoutBusiness.GetHomePageDetail(date);
        }
    }
}
