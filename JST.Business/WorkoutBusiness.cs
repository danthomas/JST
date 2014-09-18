using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DTS.AppFramework.Core;
using JST.Business.Models;
using JST.Core;
using JST.DataAccess;
using JST.Domain;
using WorkoutType = JST.Business.Models.WorkoutType;

namespace JST.Business
{
    public class WorkoutBusiness : BusinessBase
    {
        private readonly IWorkoutDateDataService _workoutDateDataService;
        private readonly IWorkoutDataService _workoutDataService;
        private readonly IResultDataService _resultDataService;

        public WorkoutBusiness(ISessionDataService sessionDataService, IWorkoutDateDataService workoutDateDataService, IRoleDataService roleDataService, IWorkoutDataService workoutDataService, IResultDataService resultDataService)
            : base(sessionDataService, roleDataService)
        {
            _workoutDateDataService = workoutDateDataService;
            _workoutDataService = workoutDataService;
            _resultDataService = resultDataService;
        }

        public ReturnValue<TrainerScheduleDetail> GetTrainerScheduleDetail(Guid sessionId, DateTime date)
        {
            return BusinessMethod(sessionId, new[] { "Trainer" }, (jstDataContext, accountId) =>
            {

                DateTime weekBeginning = new DateTime(date.Year, date.Month, date.Day);
                while (weekBeginning.DayOfWeek != DayOfWeek.Monday)
                {
                    weekBeginning = weekBeginning.AddDays(-1);
                }

                DataSet dataSet = _workoutDataService.SelectTrainerScheduleDetail(jstDataContext, date);

                List<WorkoutType> workoutTypes = dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new WorkoutType(item.Field<byte>("WorkoutTypeId"), item.Field<string>("Name"))).ToList();
                List<TrainerScheduleDetail.WorkoutDate> workoutDates = dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new TrainerScheduleDetail.WorkoutDate(item.Field<int>("WorkoutDateId"), item.Field<DateTime>("Date"), item.Field<string>("Comment"))).ToList();
                List<TrainerScheduleDetail.Workout> workouts = dataSet.Tables[2].Rows.Cast<DataRow>().Select(item => new TrainerScheduleDetail.Workout(item.Field<int>("WorkoutId"), item.Field<byte>("WorkoutTypeId"), item.Field<string>("Detail"), item.Field<DateTime>("Date"))).ToList();
                List<TrainerScheduleDetail.WorkoutDay> workoutDays = new List<TrainerScheduleDetail.WorkoutDay>();

                for (int i = 0; i < 7; ++i)
                {
                    DateTime workoutDate = weekBeginning.AddDays(i);
                    TrainerScheduleDetail.WorkoutDate wokroutDate = workoutDates.SingleOrDefault(item => item.Date == workoutDate);
                    string comment = null;

                    if (wokroutDate != null)
                    {
                        comment = wokroutDate.Comment;
                    }

                    TrainerScheduleDetail.WorkoutDay workoutDay = new TrainerScheduleDetail.WorkoutDay(workoutDate, comment);



                    foreach (WorkoutType workoutType in workoutTypes)
                    {
                        TrainerScheduleDetail.Workout workout = workouts.SingleOrDefault(item => item.Date == workoutDate && item.WorkoutTypeId == workoutType.WorkoutTypeId);

                        workoutDay.Workouts.Add(workout ?? new TrainerScheduleDetail.Workout(0, workoutType.WorkoutTypeId, "", workoutDate));
                    }

                    workoutDays.Add(workoutDay);
                }


                TrainerScheduleDetail trainerScheduleDetail = new TrainerScheduleDetail(weekBeginning,
                    workoutTypes,
                    workoutDays);


                return new ReturnValue<TrainerScheduleDetail>(true, trainerScheduleDetail);
            }, exception => new ReturnValue<TrainerScheduleDetail>(false, MessageType.Error, "Failed to load Schedule.", null));
        }

        public ReturnValue<HomePageDetail> GetCompetitorScheduleDetail(Guid sessionId, DateTime date)
        {
            return BusinessMethod(sessionId, new[] { "Competitor" }, (jstDataContext, accountId) =>
            {
                DateTime weekBeginning = new DateTime(date.Year, date.Month, date.Day);
                while (weekBeginning.DayOfWeek != DayOfWeek.Monday)
                {
                    weekBeginning = weekBeginning.AddDays(-1);
                }

                DataSet dataSet = _workoutDataService.SelectMemberHomePageDetail(jstDataContext, date, accountId);

                return new ReturnValue<HomePageDetail>(true, new HomePageDetail(weekBeginning,
                    dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new WorkoutType(item.Field<byte>("WorkoutTypeId"), item.Field<string>("Name"))),
                    dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new HomePageDetail.WorkoutDate(item.Field<int>("WorkoutDateId"), item.Field<DateTime>("Date"), item.Field<string>("Comment"), item.Field<string>("ResultDetail"))),
                    dataSet.Tables[2].Rows.Cast<DataRow>().Select(item => new HomePageDetail.Workout(item.Field<int>("WorkoutId"), item.Field<byte>("WorkoutTypeId"), item.Field<string>("Detail"), item.Field<DateTime>("Date")))));
            }, exception => new ReturnValue<HomePageDetail>(false, MessageType.Error, "Failed to load Schedule.", null));
        }

        public ReturnValue<MemberWorkoutDayDetail> GetCompetitorWorkoutDayDetail(Guid sessionId, Direction direction, DateTime date)
        {
            return BusinessMethod(sessionId, new[] { "Competitor" }, (jstDataContext, accountId) =>
            {
                DataSet dataSet = _workoutDataService.SelectMemberWorkoutDayDetails(jstDataContext, date, direction.ToString(), accountId);
                string comment = null;
                int workoutDateId = 0;
                int resultId = 0;
                string resultDetail = "";

                if (dataSet.Tables[1].Rows.Count == 1)
                {
                    workoutDateId = dataSet.Tables[1].Rows[0].Field<int>("WorkoutDateId");
                    date = dataSet.Tables[1].Rows[0].Field<DateTime>("Date");
                    comment = dataSet.Tables[1].Rows[0].Field<string>("Comment") ?? "";
                    resultId = dataSet.Tables[1].Rows[0].Field<int?>("ResultId") ?? 0;
                    resultDetail = dataSet.Tables[1].Rows[0].Field<string>("ResultDetail") ?? "";
                }

                return new ReturnValue<MemberWorkoutDayDetail>(true, new MemberWorkoutDayDetail(date,
                    comment,
                    dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new MemberWorkoutDayDetail.Workout(item.Field<int>("WorkoutId"), item.Field<string>("WorkoutTypeName"), item.Field<string>("WorkoutDetail"))), workoutDateId, resultId, resultDetail));
            }, exception => new ReturnValue<MemberWorkoutDayDetail>(false, MessageType.Error, "Failed to load Workout Day.", null));
        }

        public ReturnValue<MemberResultsDetail> GetCompetitorResultsDetail(Guid sessionId, Direction direction, DateTime date)
        {
            return BusinessMethod(sessionId, new[] {"Trainer", "Competitor"}, (jstDataContext, accountId) =>
            {
                DataSet dataSet = _workoutDataService.SelectMemberResultsDetails(jstDataContext, date, direction.ToString(), accountId);
                string comment = null;

                if (dataSet.Tables[0].Rows.Count == 1)
                {
                    date = dataSet.Tables[0].Rows[0].Field<DateTime>("Date");
                    comment = dataSet.Tables[0].Rows[0].Field<string>("Comment");
                }

                return new ReturnValue<MemberResultsDetail>(true, new MemberResultsDetail(date,
                    comment,
                    dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new MemberResultsDetail.Workout(item.Field<int>("WorkoutId"), item.Field<string>("WorkoutTypeName"), item.Field<string>("WorkoutDetail"))),
                    dataSet.Tables[2].Rows.Cast<DataRow>().Select(item => new MemberResultsDetail.Result(item.Field<int>("ResultId"), item.Field<bool>("IsCurrentAccount"), item.Field<string>("AccountDisplayName"), item.Field<string>("ResultDetail")))));

            }, exception => new ReturnValue<MemberResultsDetail>(false, MessageType.Error, "Failed to load Workout Day.", null));
        }

        public ReturnValue<CompetitorMyResultsDetail> GetCompetitorMyResultsDetail(Guid sessionId)
        {
            return BusinessMethod(sessionId, new[] { "Competitor" }, (jstDataContext, accountId) =>
            {
                DataSet dataSet = _workoutDataService.SelectCompetitorMyResultsDetails(jstDataContext, accountId);

                List<CompetitorMyResultsDetail.WorkoutType> workoutTypes = dataSet.Tables[0].Rows.Cast<DataRow>().Select(item => new CompetitorMyResultsDetail.WorkoutType(item.Field<byte>("WorkoutTypeId"), item.Field<string>("Name"))).ToList();
                var workoutDates = dataSet.Tables[1].Rows.Cast<DataRow>().Select(item => new { WorkoutDateId = item.Field<int>("WorkoutDateId"), Date = item.Field<DateTime>("Date"), ResultDetail = item.Field<string>("ResultDetail") }).ToList();
                var workouts = dataSet.Tables[2].Rows.Cast<DataRow>().Select(item => new { WorkoutDateId = item.Field<int>("WorkoutDateId"), WorkoutTypeId = item.Field<byte>("WorkoutTypeId"), WorkoutDetail = item.Field<string>("WorkoutDetail") }).ToList();

                List<CompetitorMyResultsDetail.WorkoutDay> workoutDays = new List<CompetitorMyResultsDetail.WorkoutDay>();

                foreach (var workoutDate in workoutDates.OrderByDescending(item => item.Date))
                {
                    CompetitorMyResultsDetail.WorkoutDay workoutDay = new CompetitorMyResultsDetail.WorkoutDay(workoutDate.WorkoutDateId, workoutDate.Date, workoutDate.ResultDetail);

                    workoutDays.Add(workoutDay);

                    foreach (var workoutType in workoutTypes)
                    {
                        var workout = workouts.SingleOrDefault(item => item.WorkoutDateId == workoutDate.WorkoutDateId && item.WorkoutTypeId == workoutType.WorkoutTypeId);

                        if (workout == null)
                        {
                            workoutDay.Workouts.Add(null);
                        }
                        else
                        {
                            workoutDay.Workouts.Add(new CompetitorMyResultsDetail.Workout(workout.WorkoutDetail));
                        }
                    }
                }

                return new ReturnValue<CompetitorMyResultsDetail>(true, new CompetitorMyResultsDetail(workoutTypes, workoutDays));
            }, exception => new ReturnValue<CompetitorMyResultsDetail>(false, MessageType.Error, "Failed to load Workout Day.", null));
        }


        public ReturnValue SaveTrainerSchedule(SaveTrainerScheduleDetail trainerSaveScheduleDetail)
        {
            return BusinessMethod(trainerSaveScheduleDetail.SessionId, new[] { "Trainer" }, (jstDataContext, accountId) =>
            {
                jstDataContext.OpenTransation();

                foreach (SaveTrainerScheduleDetail.WorkoutDay workoutDay in trainerSaveScheduleDetail.WorkoutDays)
                {
                    UpsertWorkoutDate(jstDataContext, workoutDay.Date, workoutDay.Comment);

                    foreach (SaveTrainerScheduleDetail.Workout workout in workoutDay.Workouts)
                    {
                        UpsertWorkout(jstDataContext, workout.WorkoutId, workout.WorkoutTypeId, workout.Date, workout.Detail);
                    }

                    _workoutDateDataService.Tidy(jstDataContext);
                }

                jstDataContext.Commit();

                return new ReturnValue(true, MessageType.Confirmation, "Schedule Saved Successfully.");
            }, exception => new ReturnValue(false, MessageType.Error, "Failed to Save Schedule."));
        }

        private void UpsertWorkoutDate(JstDataContext jstDataContext, DateTime date, string comment)
        {
            WorkoutDate workoutDate = _workoutDateDataService.SelectByDate(jstDataContext, date);

            if (workoutDate == null && !String.IsNullOrWhiteSpace(comment))
            {
                workoutDate = new WorkoutDate(0, date, comment);
                _workoutDateDataService.Insert(jstDataContext, workoutDate);
            }
            else if (workoutDate != null)
            {
                workoutDate.Comment = comment;
                _workoutDateDataService.Update(jstDataContext, workoutDate);
            }
        }

        private void UpsertWorkout(JstDataContext jstDataContext, int workoutId, byte workoutTypeId, DateTime date, string detail)
        {
            if (workoutId > 0)
            {
                Workout workout = _workoutDataService.SelectByWorkoutId(jstDataContext, workoutId);

                if (String.IsNullOrWhiteSpace(detail))
                {
                    _workoutDataService.Delete(jstDataContext, workoutId);
                }
                else
                {
                    workout.Detail = detail;

                    _workoutDataService.Update(jstDataContext, workout);

                }
            }
            else if (!String.IsNullOrWhiteSpace(detail))
            {
                WorkoutDate workoutDate = _workoutDateDataService.SelectByDate(jstDataContext, date);

                if (workoutDate == null)
                {
                    workoutDate = new WorkoutDate(0, date, "");
                    _workoutDateDataService.Insert(jstDataContext, workoutDate);
                }

                Workout workout = new Workout(0, workoutDate.WorkoutDateId, workoutTypeId, detail);

                _workoutDataService.Insert(jstDataContext, workout);
            }
        }

        public ReturnValue<int> SaveResult(Guid sessionId, int resultId, int workoutDateId, string resultDetail)
        {
            return BusinessMethod(sessionId, new[] { "Competitor" }, (jstDataContext, accountId) =>
            {
                jstDataContext.OpenTransation();

                Result result;

                if (resultId == 0)
                {
                    if (!String.IsNullOrWhiteSpace(resultDetail))
                    {
                        result = new Result(0, workoutDateId, accountId, resultDetail);
                        _resultDataService.Insert(jstDataContext, result);
                        resultId = result.ResultId;
                    }
                }
                else
                {
                    result = _resultDataService.SelectByResultId(jstDataContext, resultId);

                    if (String.IsNullOrWhiteSpace(resultDetail))
                    {
                        _resultDataService.Delete(jstDataContext, resultId);
                    }
                    else
                    {
                        result.Detail = resultDetail;

                        if (result.WorkoutDateId != workoutDateId)
                        {
                            return new ReturnValue<int>(false, MessageType.Error, "Invalid WorkoutDateId", resultId);
                        }

                        _resultDataService.Update(jstDataContext, result);
                    }
                }

                jstDataContext.Commit();

                return new ReturnValue<int>(true, resultId);

            }, exception => new ReturnValue<int>(false, MessageType.Error, "Failed to save Result.", 0));
        }
    }
}
