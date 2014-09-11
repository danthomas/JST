create proc Competitors.Workout_SelectCompetitorMyResultsDetail
	@AccountId smallint
AS

select		wd.WorkoutDateId
			, r.ResultId
			, wd.Date
			, r.Detail ResultDetail
from		Competitors.WorkoutDate wd
left join	Competitors.Result r on wd.WorkoutDateId = r.WorkoutDateId
where		isnull(r.AccountId, @AccountId) = @AccountId
order by	wd.Date desc

select		wd.WorkoutDateId
			, wt.Name WorkoutTypeName
			, w.Detail WorkoutDetail
from		Competitors.WorkoutDate wd
join		Competitors.Workout w on wd.WorkoutDateId = w.WorkoutDateId
join		Competitors.WorkoutType wt on w.WorkoutTypeId = wt.WorkoutTypeId

