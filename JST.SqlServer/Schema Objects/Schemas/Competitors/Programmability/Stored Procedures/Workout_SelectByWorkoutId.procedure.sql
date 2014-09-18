CREATE PROCEDURE [Competitors].[Workout_SelectByWorkoutId]
(
@WorkoutId INT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Competitors].[Workout] x
WHERE   x.WorkoutId = @WorkoutId


