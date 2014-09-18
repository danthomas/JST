CREATE PROCEDURE [Logging].[Exception_Insert]
(
  @Message VARCHAR(MAX)
, @StackTrace VARCHAR(MAX)
, @DateTime DATETIME
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Logging].[Exception] ([Message], [StackTrace], [DateTime])
VALUES (@Message, @StackTrace, @DateTime)



SELECT CAST(SCOPE_IDENTITY() AS INT)


