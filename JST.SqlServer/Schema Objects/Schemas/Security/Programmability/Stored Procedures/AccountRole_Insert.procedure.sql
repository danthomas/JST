CREATE PROCEDURE [Security].[AccountRole_Insert]
(
  @RoleId TINYINT
, @AccountId SMALLINT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Security].[AccountRole] ([RoleId], [AccountId])
VALUES (@RoleId, @AccountId)



SELECT CAST(SCOPE_IDENTITY() AS SMALLINT)


