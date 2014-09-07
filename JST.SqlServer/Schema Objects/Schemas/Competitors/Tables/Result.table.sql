CREATE TABLE [Competitors].[Result]
(
  [ResultId] INT NOT NULL IDENTITY (1, 1)
, [WorkoutDateId] INT NOT NULL
, [AccountId] SMALLINT NOT NULL
, [Detail] VARCHAR(1000) NOT NULL
, CONSTRAINT PK_Result PRIMARY KEY CLUSTERED ( [ResultId] )
, CONSTRAINT FK_Result_WorkoutDateId FOREIGN KEY ( WorkoutDateId ) REFERENCES Competitors.WorkoutDate ( WorkoutDateId )
, CONSTRAINT FK_Result_AccountId FOREIGN KEY ( AccountId ) REFERENCES Security.Account ( AccountId )
)
GO
CREATE UNIQUE NONCLUSTERED INDEX AK_Result_WorkoutDateId_AccountId ON [Competitors].[Result]
(
	[WorkoutDateId] ASC, [AccountId] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]