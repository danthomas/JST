CREATE TABLE [Security].[AccountRole]
(
  [AccountRoleId] SMALLINT NOT NULL IDENTITY (1, 1)
, [RoleId] TINYINT NOT NULL
, [AccountId] SMALLINT NOT NULL
, CONSTRAINT PK_AccountRole PRIMARY KEY CLUSTERED ( [AccountRoleId] )
, CONSTRAINT FK_AccountRole_RoleId FOREIGN KEY ( RoleId ) REFERENCES Security.Role ( RoleId )
, CONSTRAINT FK_AccountRole_AccountId FOREIGN KEY ( AccountId ) REFERENCES Security.Account ( AccountId )
)
