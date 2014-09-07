CREATE TABLE [Competitors].[Workout]
(
  [WorkoutId] INT NOT NULL IDENTITY (1, 1)
, [WorkoutDateId] INT NOT NULL
, [WorkoutTypeId] TINYINT NOT NULL
, [Detail] VARCHAR(1000) NOT NULL
, CONSTRAINT PK_Workout PRIMARY KEY CLUSTERED ( [WorkoutId] )
, CONSTRAINT FK_Workout_WorkoutDateId FOREIGN KEY ( WorkoutDateId ) REFERENCES Competitors.WorkoutDate ( WorkoutDateId )
, CONSTRAINT FK_Workout_WorkoutTypeId FOREIGN KEY ( WorkoutTypeId ) REFERENCES Competitors.WorkoutType ( WorkoutTypeId )
)
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_Workout_WorkoutDateId_WorkoutTypeId ON [Competitors].[Workout]
(
	[WorkoutDateId] ASC, [WorkoutTypeId] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]