create proc Competitors.Workout_SelectMemberWorkoutDayDetail
@date date
, @direction varchar(10)
, @accountId smallint
as

declare @workoutDateId int = Competitors.GetWorkoutId(@date, @direction)

select		w.WorkoutId
			, wt.Name WorkoutTypeName
			, w.Detail WorkoutDetail
from		Competitors.Workout w
join		Competitors.WorkoutType wt on w.WorkoutTypeId = wt.WorkoutTypeId
where		w.WorkoutDateId = @workoutDateId
order by	wt.SortOrder

select		wd.WorkoutDateId
			, wd.Date
			, wd.Comment
			, r.ResultId
			, r.Detail ResultDetail
from		Competitors.WorkoutDate wd
left join	(select r.ResultId, r.WorkoutDateId, r.Detail from Competitors.Result r where r.AccountId = @accountId) r on wd.WorkoutDateId = r.WorkoutDateId
where		wd.WorkoutDateId = @workoutDateId