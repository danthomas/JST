CREATE PROCEDURE [Competitors].[WorkoutDate_Insert]
(
  @Date DATE
, @Comment VARCHAR(2000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Competitors].[WorkoutDate] ([Date], [Comment])
VALUES (@Date, @Comment)



SELECT CAST(SCOPE_IDENTITY() AS INT)


