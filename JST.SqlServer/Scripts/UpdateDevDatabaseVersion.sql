print 'Updating database Jst version to 1.1.0';
go
sys.sp_updateextendedproperty @name=N'Version', @value='1.1.0'