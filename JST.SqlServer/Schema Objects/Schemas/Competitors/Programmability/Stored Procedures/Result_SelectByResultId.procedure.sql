CREATE PROCEDURE [Competitors].[Result_SelectByResultId]
(
@ResultId INT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Competitors].[Result] x
WHERE   x.ResultId = @ResultId


