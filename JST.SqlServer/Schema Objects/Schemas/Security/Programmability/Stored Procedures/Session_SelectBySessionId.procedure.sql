CREATE PROCEDURE [Security].[Session_SelectBySessionId]
(
@SessionId UNIQUEIDENTIFIER
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  *
FROM    [Security].[Session] x
WHERE   x.SessionId = @SessionId


