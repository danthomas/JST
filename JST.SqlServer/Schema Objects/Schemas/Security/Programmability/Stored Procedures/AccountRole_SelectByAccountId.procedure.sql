CREATE PROCEDURE [Security].[AccountRole_SelectByAccountId]
(
@AccountId SMALLINT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[AccountRole] x
WHERE   x.AccountId = @AccountId


