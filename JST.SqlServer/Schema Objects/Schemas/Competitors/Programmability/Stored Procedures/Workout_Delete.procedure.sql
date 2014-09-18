CREATE PROCEDURE [Competitors].[Workout_Delete]
(
  @WorkoutId INT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DELETE [Competitors].[Workout]
WHERE [WorkoutId] = @WorkoutId