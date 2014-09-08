create proc Competitors.Workout_SelectMemberHomePageDetail
@date date
, @accountId smallint
as

while (datename(weekday, @date) != 'Monday')
begin
	set @date = dateadd(d, -1, @date)
end

select		wt.WorkoutTypeId
			, wt.Name
from		Competitors.WorkoutType wt
order by	wt.SortOrder


select		wd.WorkoutDateId
			, wd.Date
			, wd.Comment
			, r.Detail ResultDetail
from		Competitors.WorkoutDate wd
left join	Competitors.Result r on wd.WorkoutDateId = r.WorkoutDateId
where		wd.Date >= @date and wd.Date < dateadd(d, 7, @date)
and			isnull(r.AccountId, @accountId) = @accountId

select		w.WorkoutId
			, w.WorkoutTypeId
			, w.Detail
			, wd.Date
from		Competitors.Workout w
join		Competitors.WorkoutDate wd on w.WorkoutDateId = wd.WorkoutDateId
where		wd.Date >= @date and wd.Date < dateadd(d, 7, @date)