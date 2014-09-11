alter proc Competitors.Workout_SelectCompetitorMyResultsDetail
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