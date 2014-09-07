CREATE TABLE [Security].[AccountType]
(
  [AccountTypeId] TINYINT NOT NULL
, [Code] VARCHAR(20) NOT NULL
, [Name] VARCHAR(50) NOT NULL
, CONSTRAINT PK_AccountType PRIMARY KEY CLUSTERED ( [AccountTypeId] )
)