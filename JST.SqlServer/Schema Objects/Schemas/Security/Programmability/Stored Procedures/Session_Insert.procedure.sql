CREATE PROCEDURE [Security].[Session_Insert]
(
  @SessionId UNIQUEIDENTIFIER
, @AccountId SMALLINT
, @StartDateTime DATETIME
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Security].[Session] ([SessionId], [AccountId], [StartDateTime])
VALUES (@SessionId, @AccountId, @StartDateTime)
