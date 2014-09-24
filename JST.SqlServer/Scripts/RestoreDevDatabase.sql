USE [master]

PRINT 'Restore started at: ' + CONVERT(varchar, GETDATE(), 121);

IF EXISTS(SELECT * FROM sys.databases WHERE [name] = 'Jst')
BEGIN
	PRINT 'Drop existing database with name: Jst';
	USE tempdb;

	DECLARE @state nvarchar(60);
	SELECT @state = state_desc FROM sys.databases WHERE [name] = 'Jst'; 
	IF ISNULL(@state,'') != 'ONLINE' 
	BEGIN
		RAISERROR('Database [Jst] is currently in the state %s - upgrade will not continue.', 16, 1, @state);
		RETURN;
	END

	ALTER DATABASE [Jst] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [Jst];
END


PRINT 'Restoring database Jst from D:\BACKUPS\danthoma_JST_Prod.bak';

RESTORE DATABASE [JST]
FROM  DISK = N'D:\BACKUPS\danthoma_JST_Prod.bak'
WITH  FILE = 1, 
MOVE N'danthoma_JST_Prod_data' TO N'D:\Data\danthoma_JST_Prod_data.mdf',  
MOVE N'danthoma_JST_Prod_log' TO N'D:\LOGS\danthoma_JST_Prod_log.ldf', 
NOUNLOAD,  
REPLACE, 
STATS = 5
GO


