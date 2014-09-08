﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DTS.AppFramework.Core;
using JST.Business.Models;
using JST.DataAccess;
using JST.Domain;
using WorkoutType = JST.Business.Models.WorkoutType;

namespace JST.Business
{
    public class WorkoutBusiness
    {
        private readonly ISessionDataService _sessionDataService;
        private readonly IWorkoutDataService _workoutDataService;
        private readonly IResultDataService _resultDataService;

        public WorkoutBusiness(ISessionDataService sessionDataService, IWorkoutDataService workoutDataService, IResultDataService resultDataService)
        {
            _sessionDataService = sessionDataService;
            _workoutDataService = workoutDataService;
            _resultDataService = resultDataService;
        }

        public HomePageDetail GetHomePageDetail(Guid sessionId, DateTime date)
        {
            Domain.Session session = _sessionDataService.SelectBySessionId(sessionId);

            if (session == null)
            {
                return null;
            }

            DateTime weekBeginning = new DateTime(date.Year, date.Month, date.Day);
            while (weekBeginning.DayOfWeek != DayOfWeek.Monday)
            {
                weekBeginning = weekBeginning.AddDays(-1);
            }

            DataSet dataSet = _workoutDataService.SelectMemberHomePageDetail(date, session.AccountId);
            return new HomePageDetail(weekBeginning,
                dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new WorkoutType(item.Field<byte>("WorkoutTypeId"), item.Field<string>("Name"))),
                dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new HomePageDetail.WorkoutDate(item.Field<int>("WorkoutDateId"), item.Field<DateTime>("Date"), item.Field<string>("Comment"), item.Field<string>("ResultDetail"))),
                dataSet.Tables[2].Rows.Cast<DataRow>().Select(item => new HomePageDetail.Workout(item.Field<int>("WorkoutId"), item.Field<byte>("WorkoutTypeId"), item.Field<string>("Detail"), item.Field<DateTime>("Date"))));
        }

        public MemberWorkoutDayDetail GetMemberWorkoutDayDetail(Guid sessionId, DateTime date)
        {
            Domain.Session session = _sessionDataService.SelectBySessionId(sessionId);

            if (session == null)
            {
                return null;
            }
            
            DataSet dataSet = _workoutDataService.SelectMemberWorkoutDayDetails(date, session.AccountId);
            int workoutDateId = 0;
            int resultId = 0;
            string resultDetail = "";

            if (dataSet.Tables[1].Rows.Count == 1)
            {
                workoutDateId = dataSet.Tables[1].Rows[0].Field<int>("WorkoutDateId");
                resultId = dataSet.Tables[1].Rows[0].Field<int?>("ResultId") ?? 0;
                resultDetail = dataSet.Tables[1].Rows[0].Field<string>("ResultDetail") ?? "";
            }

            return new MemberWorkoutDayDetail(date,
                dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new MemberWorkoutDayDetail.Workout(item.Field<int>("WorkoutId"), item.Field<string>("WorkoutTypeName"), item.Field<string>("WorkoutDetail"))), workoutDateId, resultId, resultDetail);

        }

        public ReturnValue<int> SaveResult(Guid sessionId, int resultId, int workoutDateId, string resultDetail)
        {
            Domain.Session session = _sessionDataService.SelectBySessionId(sessionId);

            if (session == null)
            {
                return new ReturnValue<int>(false, MessageType.Error, "Unauthorised Access", resultId);
            }

            Result result;

            if (resultId == 0)
            {
                result = new Result(0, workoutDateId, session.AccountId, resultDetail);
                _resultDataService.Insert(result);
                resultId = result.ResultId;

            }
            else
            {
                result = _resultDataService.SelectByResultId(resultId);
                result.Detail = resultDetail;

                if (result.WorkoutDateId != workoutDateId)
                {
                    return new ReturnValue<int>(false, MessageType.Error, "Invalid WorkoutDateId", resultId);
                }

                _resultDataService.Update(result);
            }
            
            return new ReturnValue<int>(true, resultId);
        }

        public IEnumerable<HomePageDetail.WorkoutDay> GetByWeek(DateTime day)
        {
            return null;// _workoutDataService.GetByWeek(day);
        }
    }
}