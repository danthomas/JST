﻿create proc Competitors.Workout_SelectCompetitorMyResultsDetail
	@AccountId smallint
AS

select		wt.WorkoutTypeId
			, wt.Name
from		Competitors.WorkoutType wt
order by	wt.SortOrder

select		wd.WorkoutDateId
			, r.ResultId
			, wd.Date
			, r.Detail ResultDetail
from		Competitors.WorkoutDate wd
left join	(
			select	*
			from	Competitors.Result
			where	AccountId = @AccountId
			) r on wd.WorkoutDateId = r.WorkoutDateId

select		wd.WorkoutDateId
			, w.WorkoutTypeId
			, w.Detail WorkoutDetail
from		Competitors.WorkoutDate wd
join		Competitors.Workout w on wd.WorkoutDateId = w.WorkoutDateId

