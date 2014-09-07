create proc Competitors.Result_SelectForMemberHomeByDate
@Date date
as

select		r.ResultId
			, a.DisplayName
			, r.Detail
from		Competitors.Result r
join		Competitors.WorkoutDate wd on r.WorkoutDateId = wd.WorkoutDateId
join		Security.Account a on r.AccountId = a.AccountId
where		wd.Date = @Date
order by	a.DisplayName

