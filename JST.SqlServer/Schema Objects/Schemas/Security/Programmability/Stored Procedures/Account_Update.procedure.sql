CREATE PROCEDURE [Security].[Account_Update]
(
  @AccountId SMALLINT
, @AccountTypeId TINYINT
, @AccountName VARCHAR(30)
, @DisplayName VARCHAR(100)
, @Password VARCHAR(30)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Security].[Account]
SET         [AccountTypeId] = @AccountTypeId
          , [AccountName] = @AccountName
          , [DisplayName] = @DisplayName
          , [Password] = @Password
WHERE       AccountId = @AccountId
