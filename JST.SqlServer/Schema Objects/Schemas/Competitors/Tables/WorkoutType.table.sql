CREATE TABLE [Competitors].[WorkoutType]
(
  [WorkoutTypeId] TINYINT NOT NULL IDENTITY (1, 1)
, [Name] VARCHAR(50) NOT NULL
, [SortOrder] TINYINT NOT NULL
, CONSTRAINT PK_WorkoutType PRIMARY KEY CLUSTERED ( [WorkoutTypeId] )
)
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_WorkoutTypeName ON [Competitors].[WorkoutType]
(
	[Name] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
