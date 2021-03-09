IF OBJECT_ID('[dbo].[sp_ProductGroup_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductGroup_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductGroup_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.ProductGroup WHERE dbo.ProductGroup.ProductGroupName LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.ProductGroup
	SET NOCOUNT OFF;
END