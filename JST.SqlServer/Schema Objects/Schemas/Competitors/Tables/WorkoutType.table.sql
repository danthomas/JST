CREATE TABLE [Competitors].[WorkoutType]
(
  [WorkoutTypeId] TINYINT NOT NULL IDENTITY (1, 1)
, [Name] VARCHAR(50) NOT NULL
, [SortOrder] TINYINT NOT NULL
, CONSTRAINT PK_WorkoutType PRIMARY KEY CLUSTERED ( [WorkoutTypeId] )
)