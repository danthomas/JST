CREATE PROCEDURE [Competitors].[WorkoutDate_SelectByDate]
(
@Date DATE
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Competitors].[WorkoutDate] x
WHERE   x.Date = @Date


