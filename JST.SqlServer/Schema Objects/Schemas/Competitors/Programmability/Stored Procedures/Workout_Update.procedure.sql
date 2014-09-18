CREATE PROCEDURE [Competitors].[Workout_Update]
(
  @WorkoutId INT
, @WorkoutDateId INT
, @WorkoutTypeId TINYINT
, @Detail VARCHAR(1000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Competitors].[Workout]
SET         [WorkoutDateId] = @WorkoutDateId
          , [WorkoutTypeId] = @WorkoutTypeId
          , [Detail] = @Detail
WHERE       WorkoutId = @WorkoutId
