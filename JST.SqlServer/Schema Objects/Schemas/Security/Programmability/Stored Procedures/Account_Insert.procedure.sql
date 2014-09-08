CREATE PROCEDURE [Security].[Account_Insert]
(
  @AccountTypeId TINYINT
, @AccountName VARCHAR(30)
, @DisplayName VARCHAR(100)
, @Password VARCHAR(30)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Security].[Account] ([AccountTypeId], [AccountName], [DisplayName], [Password])
VALUES (@AccountTypeId, @AccountName, @DisplayName, @Password)


SELECT CAST(SCOPE_IDENTITY() AS SMALLINT)


