CREATE PROCEDURE [Security].Account_SelectAll
AS
SELECT		*
FROM		Security.Account a
ORDER BY	a.AccountName
