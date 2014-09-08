CREATE PROCEDURE [Competitors].[Result_Update]
(
  @ResultId INT
, @WorkoutDateId INT
, @AccountId SMALLINT
, @Detail VARCHAR(1000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Competitors].[Result]
SET         [WorkoutDateId] = @WorkoutDateId
          , [AccountId] = @AccountId
          , [Detail] = @Detail
WHERE       ResultId = @ResultId
