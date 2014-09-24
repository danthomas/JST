/****** Object:  Login [danthoma_jst]    Script Date: 24/09/2014 14:25:42 ******/
CREATE LOGIN [danthoma_jst] WITH PASSWORD=N'', DEFAULT_DATABASE=[JST], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE SCHEMA [danthoma_jst]
GO

CREATE USER [danthoma_jst] FOR LOGIN [danthoma_jst] WITH DEFAULT_SCHEMA=[danthoma_jst]
GO

ALTER ROLE [db_owner] ADD MEMBER [danthoma_jst]
GO
