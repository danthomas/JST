create proc Competitors.Workout_SelectMemberResultsDetail
@date date
, @direction varchar(10)
, @accountId smallint
as

declare @workoutDateId int = Competitors.GetWorkoutId(@date, @direction)

select		wd.Date
from		Competitors.WorkoutDate wd
where		wd.WorkoutDateId = @workoutDateId

select		w.WorkoutId
			, wt.Name WorkoutTypeName
			, w.Detail WorkoutDetail
from		Competitors.Workout w
join		Competitors.WorkoutType wt on w.WorkoutTypeId = wt.WorkoutTypeId
where		w.WorkoutDateId = @workoutDateId
order by	wt.SortOrder

select		ResultId
			, cast(case when a.AccountId = @accountId then 1 else 0 end as bit) IsCurrentAccount
			, a.DisplayName AccountDisplayName
			, r.Detail ResultDetail
from		Competitors.Result r
join		Security.Account a on r.AccountId = a.AccountId
where		r.WorkoutDateId = @workoutDateId
order by	a.DisplayName