CREATE PROCEDURE [Competitors].[Result_Delete]
(
  @ResultId INT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DELETE [Competitors].[Result]
WHERE [ResultId] = @ResultId