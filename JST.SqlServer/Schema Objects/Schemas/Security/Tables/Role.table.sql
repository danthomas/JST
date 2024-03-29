CREATE TABLE [Security].[Role]
(
  [RoleId] TINYINT NOT NULL
, [Code] VARCHAR(20) NOT NULL
, [Name] VARCHAR(50) NOT NULL
, CONSTRAINT PK_Role PRIMARY KEY CLUSTERED ( [RoleId] )
)
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_RoleCode ON [Security].[Role]
(
	[Code] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_RoleName ON [Security].[Role]
(
	[Name] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
