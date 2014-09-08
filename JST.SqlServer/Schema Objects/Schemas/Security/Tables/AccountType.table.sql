CREATE TABLE [Security].[AccountType]
(
  [AccountTypeId] TINYINT NOT NULL
, [Code] VARCHAR(20) NOT NULL
, [Name] VARCHAR(50) NOT NULL
, CONSTRAINT PK_AccountType PRIMARY KEY CLUSTERED ( [AccountTypeId] )
)
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_AccountType_Code ON [Security].[AccountType]
(
	[Code] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_AccountType_Name ON [Security].[AccountType]
(
	[Name] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
