IF OBJECT_ID('[dbo].[sp_User_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.[User] WHERE dbo.[User].LastName LIKE '%'+@searchString+'%' AND dbo.[User].Level != 1
	else
		SELECT * FROM dbo.[User]
	SET NOCOUNT OFF;
END