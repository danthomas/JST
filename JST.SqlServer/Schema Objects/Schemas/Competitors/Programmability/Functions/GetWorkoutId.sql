create function Competitors.GetWorkoutId
(
@date date
, @direction varchar(10)
)
returns int
as
begin
	declare @workoutDateId int =	(
									select wd.WorkoutDateId
									from Competitors.WorkoutDate wd
									where wd.Date = @date
									)

	if @workoutDateId is null
	begin

		if (@direction = 'next')
		begin 
			select @workoutDateId = (	select top 1 wd.WorkoutDateId
										from Competitors.WorkoutDate wd
										where wd.Date > @date
										order by wd.Date
									)

			if @workoutDateId is null
			begin
				select @workoutDateId = (	select top 1 wd.WorkoutDateId
											from Competitors.WorkoutDate wd
											order by wd.Date desc
										)
			end
		end
		else
		begin
			select @workoutDateId = (	select top 1 wd.WorkoutDateId
										from Competitors.WorkoutDate wd
										where wd.Date < @date
										order by wd.Date desc
									)

			if @workoutDateId is null
			begin
				select @workoutDateId = (	select top 1 wd.WorkoutDateId
											from Competitors.WorkoutDate wd
											order by wd.Date
										)
			end
		end

	end

	return @workoutDateId
end