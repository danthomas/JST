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
        [Route("api/workout/homepageDetail")]
        public ReturnValue<HomePageDetail> GetHomePageDetail([FromBody]GetHomePageRequestDetail requestDetail)
        {
            return new ReturnValue<HomePageDetail>(true, _workoutBusiness.GetHomePageDetail(requestDetail.SessionId, requestDetail.Date));
        }

        [HttpPost]
        [Route("api/workout/memberWorkoutDayDetail")]
        public ReturnValue<MemberWorkoutDayDetail> GetWorkoutDay([FromBody]GetWorkoutDayRequestDetail requestValue)
        {
            return new ReturnValue<MemberWorkoutDayDetail>(true, _workoutBusiness.GetMemberWorkoutDayDetail(requestValue.SessionId, requestValue.Direction, requestValue.Date));
        }

        [HttpPost]
        [Route("api/workout/memberResultsDetail")]
        public ReturnValue<MemberResultsDetail> GetResults([FromBody]GetMemberResultsRequestDetail requestValue)
        {
            return new ReturnValue<MemberResultsDetail>(true, _workoutBusiness.GetMemberResultsDetail(requestValue.SessionId, requestValue.Direction, requestValue.Date));
        }

        [HttpPost]
        [Route("api/workout/saveResult")]
        public ReturnValue SaveResult([FromBody]SaveResultDetail requestValue)
        {
            return _workoutBusiness.SaveResult(requestValue.SessionId, requestValue.ResultId, requestValue.WorkoutDateId, requestValue.ResultDetail);
        }

        public class GetHomePageRequestDetail
        {
            public Guid SessionId { get; set; }
            public DateTime Date { get; set; }
        }

        public class GetWorkoutDayRequestDetail
        {
            public Guid SessionId { get; set; }
            public Direction Direction { get; set; }
            public DateTime Date { get; set; }
        }

        public class GetMemberResultsRequestDetail
        {
            public Guid SessionId { get; set; }
            public Direction Direction { get; set; }
            public DateTime Date { get; set; }
        }

        public class SaveResultDetail
        {
            public Guid SessionId { get; set; }
            public int ResultId { get; set; }
            public int WorkoutDateId { get; set; }
            public string ResultDetail { get; set; }

        }
    }
}
