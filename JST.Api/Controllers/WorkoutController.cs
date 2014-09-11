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
        [Route("api/workout/competitorScheduleDetail")]
        public ReturnValue<HomePageDetail> GetCompetitorScheduleDetail([FromBody]GetHomePageRequestDetail requestDetail)
        {
            return new ReturnValue<HomePageDetail>(true, _workoutBusiness.GetCompetitorScheduleDetail(requestDetail.SessionId, requestDetail.Date));
        }

        [HttpPost]
        [Route("api/workout/competitorWorkoutDayDetail")]
        public ReturnValue<MemberWorkoutDayDetail> GetCompetitorWorkoutDayDetail([FromBody]GetWorkoutDayRequestDetail requestValue)
        {
            return new ReturnValue<MemberWorkoutDayDetail>(true, _workoutBusiness.GetCompetitorWorkoutDayDetail(requestValue.SessionId, requestValue.Direction, requestValue.Date));
        }

        [HttpPost]
        [Route("api/workout/competitorResultsDetail")]
        public ReturnValue<MemberResultsDetail> GetCompetitorResultsDetail([FromBody]GetMemberResultsRequestDetail requestValue)
        {
            return new ReturnValue<MemberResultsDetail>(true, _workoutBusiness.GetCompetitorResultsDetail(requestValue.SessionId, requestValue.Direction, requestValue.Date));
        }

        [HttpPost]
        [Route("api/workout/competitorMyResultsDetail")]
        public ReturnValue<CompetitorMyResultsDetail> GetMyCompetitorResultsDetail([FromBody]GetMemberResultsRequestDetail requestValue)
        {
            return new ReturnValue<CompetitorMyResultsDetail>(true, _workoutBusiness.GetCompetitorMyResultsDetail(requestValue.SessionId));
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
