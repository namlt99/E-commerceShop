IF OBJECT_ID('[dbo].[sp_Category_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Category_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Category_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.Category WHERE dbo.Category.CategoryName LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.Category
	SET NOCOUNT OFF;
END