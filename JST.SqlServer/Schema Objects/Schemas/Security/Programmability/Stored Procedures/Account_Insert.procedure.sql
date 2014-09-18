CREATE PROCEDURE [Security].[Account_Insert]
(
  @AccountName VARCHAR(30)
, @DisplayName VARCHAR(100)
, @Email VARCHAR(200)
, @Password VARCHAR(1000)
, @ChangePassword BIT
, @IsActive BIT
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

INSERT INTO [Security].[Account] ([AccountName], [DisplayName], [Email], [Password], [ChangePassword], [IsActive])
VALUES (@AccountName, @DisplayName, @Email, @Password, @ChangePassword, @IsActive)



SELECT CAST(SCOPE_IDENTITY() AS SMALLINT)


