CREATE PROCEDURE [Security].[Account_Update]
(
  @AccountId SMALLINT
, @AccountName VARCHAR(30)
, @DisplayName VARCHAR(100)
, @Email VARCHAR(200)
, @Password VARCHAR(1000)
, @ChangePassword BIT
, @IsActive BIT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE      [Security].[Account]
SET         [AccountName] = @AccountName
          , [DisplayName] = @DisplayName
          , [Email] = @Email
          , [Password] = @Password
          , [ChangePassword] = @ChangePassword
          , [IsActive] = @IsActive
WHERE       AccountId = @AccountId
