CREATE PROCEDURE [Competitors].[Workout_Insert]
(
  @WorkoutDateId INT
, @WorkoutTypeId TINYINT
, @Detail VARCHAR(1000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Competitors].[Workout] ([WorkoutDateId], [WorkoutTypeId], [Detail])
VALUES (@WorkoutDateId, @WorkoutTypeId, @Detail)



SELECT CAST(SCOPE_IDENTITY() AS INT)


