IF OBJECT_ID('[dbo].[sp_Contact_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Contact_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Contact_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.Contact WHERE dbo.Contact.Content LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.Contact
	SET NOCOUNT OFF;
END