create proc Competitors.Workout_SelectMemberResultsDetail
@date date
, @accountId smallint
as

select		ResultId
			, cast(case when a.AccountId = @accountId then 1 else 0 end as bit) IsCurrentAccount
			, a.DisplayName AccountDisplayName
			, r.Detail ResultDetail
from		Competitors.Result r
join		Competitors.WorkoutDate wd on r.WorkoutDateId = wd.WorkoutDateId
join		Security.Account a on r.AccountId = a.AccountId
where		wd.Date = @date
order by	a.DisplayName