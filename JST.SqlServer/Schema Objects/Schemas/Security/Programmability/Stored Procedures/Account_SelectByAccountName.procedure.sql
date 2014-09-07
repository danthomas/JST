CREATE PROCEDURE [Security].[Account_SelectByAccountName]
(
@AccountName VARCHAR(30)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[Account] x
WHERE   x.AccountName = @AccountName


