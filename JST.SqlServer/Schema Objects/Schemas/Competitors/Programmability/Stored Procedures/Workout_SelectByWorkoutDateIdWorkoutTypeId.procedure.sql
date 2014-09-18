CREATE PROCEDURE [Competitors].[Workout_SelectByWorkoutDateIdWorkoutTypeId]
(
@WorkoutDateId INT
, @WorkoutTypeId TINYINT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Competitors].[Workout] x
WHERE   x.WorkoutDateId = @WorkoutDateId
AND     x.WorkoutTypeId = @WorkoutTypeId


