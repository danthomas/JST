CREATE PROCEDURE [Competitors].[WorkoutDate_Update]
(
  @WorkoutDateId INT
, @Date DATE
, @Comment VARCHAR(2000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Competitors].[WorkoutDate]
SET         [Date] = @Date
          , [Comment] = @Comment
WHERE       WorkoutDateId = @WorkoutDateId
