CREATE PROCEDURE [Security].[Account_Update]
(
  @AccountId SMALLINT
, @AccountName VARCHAR(30)
, @DisplayName VARCHAR(100)
, @Password VARCHAR(30)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Security].[Account]
SET         [AccountName] = @AccountName
          , [DisplayName] = @DisplayName
          , [Password] = @Password
WHERE       AccountId = @AccountId
