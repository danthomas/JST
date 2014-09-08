create proc Competitors.Workout_SelectMemberWorkoutDayDetail
@date date
, @accountId smallint
as


select		w.WorkoutId
			, wt.Name WorkoutTypeName
			, w.Detail WorkoutDetail
from		Competitors.Workout w
join		Competitors.WorkoutType wt on w.WorkoutTypeId = wt.WorkoutTypeId
join		Competitors.WorkoutDate wd on w.WorkoutDateId = wd.WorkoutDateId
where		wd.Date = @date
order by	wt.SortOrder

select		wd.WorkoutDateId
			, r.ResultId
			, r.Detail ResultDetail
from		Competitors.WorkoutDate wd
left join	(select r.ResultId, r.WorkoutDateId, r.Detail from Competitors.Result r where r.AccountId = @accountId) r on wd.WorkoutDateId = r.WorkoutDateId
where		wd.Date = @date