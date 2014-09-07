CREATE PROCEDURE [Security].[Account_SelectByAccountId]
(
@AccountId SMALLINT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[Account] x
WHERE   x.AccountId = @AccountId


