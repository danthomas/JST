/*
check that the database is at the required version 
*/

declare @actualVersion varchar(10)
		, @requiredVersion varchar(10) = '1.0'

select	@actualVersion = cast(value as varchar(10))
from	fn_listextendedproperty (NULL, NULL, NULL, NULL, NULL, NULL, default)
where	objname is null
and		objtype is null
and		name = 'Version'

PRINT 'Checking that database Jst is at version ' + @requiredVersion;

if (@actualVersion != @requiredVersion)
begin
	raiserror('Database Jst is currently at version %s - build will not continue.', 16, 1, @actualVersion);
end
