CREATE PROCEDURE [Security].[AccountType_SelectByAccountTypeId]
(
@AccountTypeId TINYINT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[AccountType] x
WHERE   x.AccountTypeId = @AccountTypeId


