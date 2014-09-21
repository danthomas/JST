CREATE PROCEDURE [Security].[Role_SelectByCode]
(
@Code VARCHAR(20)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[Role] x
WHERE   x.Code = @Code


