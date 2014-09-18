create proc Competitors.WorkoutDate_Tidy
as
delete	wd
from	Competitors.WorkoutDate wd
where	wd.WorkoutDateId not in (select distinct WorkoutDateId from Competitors.Workout)
and		wd.WorkoutDateId not in (select distinct WorkoutDateId from Competitors.Result)