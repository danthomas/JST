CREATE PROCEDURE [Security].[Account_DeleteMany]
(
@Ids VARBINARY(MAX)
)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DELETE  x
FROM    [Security].[Account] x
JOIN    [dbo].[ConvertBinaryToSmallInt](@Ids) ids on [x].[AccountId] = [ids].[Value]
