/*
select distinct a.* from
security.account a
join Competitors.Result r on a.AccountId = r.AccountId
where accountname like 'account%'

select * from
security.account
where displayname like '%pig%'
*/

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'passantc')
where accountid in (select accountid from Security.Account where DisplayName in ('MR Chris ''Rocktape'' Passant', 'Sir Chris ''Rocktape'' Petals'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'MairsB')
where accountid in (select accountid from Security.Account where DisplayName in ('Barry Mairs'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'CoopC')
where accountid in (select accountid from Security.Account where DisplayName in ('Claire Coop', 'Claire ''pumpinicle bread'' Coop'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'AinscoughA')
where accountid in (select accountid from Security.Account where DisplayName in ('Smart price AA battery'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'ClarkeB')
where accountid in (select accountid from Security.Account where DisplayName in ('Brad "Big Shag" Clarke', 'Brad "I shag all JST Members" Clarke'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'CornthwaiteJ')
where accountid in (select accountid from Security.Account where DisplayName in ('Jak "Fat Boy" Cornthwaite aka Twat aka Part timer'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'MurphyS')
where accountid in (select accountid from Security.Account where DisplayName in ('Marah Surphy'))

update competitors.Result
set accountid = (select accountid from Security.Account where accountname = 'FletcherL')
where accountid in (select accountid from Security.Account where DisplayName in ('Beans on toast'))




delete Security.AccountRole
where accountid in (
	select AccountId
	from Security.Account
	where AccountId not in (select accountid from Competitors.Result)
	and AccountName like 'account%'
	)


delete Security.Account 
where AccountId not in (select accountid from Competitors.Result)
and AccountName like 'account%'



delete Competitors.WorkoutDate
where workoutdateid not in (select distinct workoutdateid from Competitors.result)
and workoutdateid not in (select distinct workoutdateid from Competitors.workout)