CREATE TABLE [Security].[Account]
(
  [AccountId] SMALLINT NOT NULL IDENTITY (1, 1)
, [AccountTypeId] TINYINT NOT NULL
, [AccountName] VARCHAR(30) NOT NULL
, [DisplayName] VARCHAR(100) NOT NULL
, [Password] VARCHAR(30) NOT NULL
, CONSTRAINT PK_Account PRIMARY KEY CLUSTERED ( [AccountId] )
, CONSTRAINT FK_Account_AccountTypeId FOREIGN KEY ( AccountTypeId ) REFERENCES Security.AccountType ( AccountTypeId )
)