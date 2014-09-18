create proc Competitors.Workout_SelectTrainerScheduleDetail
	@date date
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
from		Competitors.WorkoutDate wd
where		wd.Date >= @date and wd.Date < dateadd(d, 7, @date)

select		w.WorkoutId
			, w.WorkoutTypeId
			, w.Detail
			, wd.Date
from		Competitors.Workout w
join		Competitors.WorkoutDate wd on w.WorkoutDateId = wd.WorkoutDateId
where		wd.Date >= @date and wd.Date < dateadd(d, 7, @date)