CREATE PROCEDURE [Competitors].[Result_Insert]
(
  @WorkoutDateId INT
, @AccountId SMALLINT
, @Detail VARCHAR(1000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Competitors].[Result] ([WorkoutDateId], [AccountId], [Detail])
VALUES (@WorkoutDateId, @AccountId, @Detail)



SELECT CAST(SCOPE_IDENTITY() AS INT)


