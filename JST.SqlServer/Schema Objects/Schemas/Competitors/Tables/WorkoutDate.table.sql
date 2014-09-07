CREATE TABLE [Competitors].[WorkoutDate]
(
  [WorkoutDateId] INT NOT NULL IDENTITY (1, 1)
, [Date] DATE NOT NULL
, [Comment] VARCHAR(2000) NOT NULL
, CONSTRAINT PK_WorkoutDate PRIMARY KEY CLUSTERED ( [WorkoutDateId] )
)