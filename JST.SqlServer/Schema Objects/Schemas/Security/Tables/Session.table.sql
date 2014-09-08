CREATE TABLE [Security].[Session]
(
  [SessionId] UNIQUEIDENTIFIER NOT NULL
, [AccountId] SMALLINT NOT NULL
, [StartDateTime] DATETIME NOT NULL
, CONSTRAINT PK_Session PRIMARY KEY CLUSTERED ( [SessionId] )
, CONSTRAINT FK_Session_AccountId FOREIGN KEY ( AccountId ) REFERENCES Security.Account ( AccountId )
)
