CREATE PROCEDURE [Security].[Session_Insert]
(
  @SessionId UNIQUEIDENTIFIER
, @AccountId SMALLINT
, @StartDateTime DATETIME
, @Client VARCHAR(1000)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Security].[Session] ([SessionId], [AccountId], [StartDateTime], [Client])
VALUES (@SessionId, @AccountId, @StartDateTime, @Client)
