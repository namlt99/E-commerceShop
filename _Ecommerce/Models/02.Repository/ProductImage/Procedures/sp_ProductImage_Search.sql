IF OBJECT_ID('[dbo].[sp_ProductImage_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductImage_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductImage_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.ProductImage WHERE dbo.ProductImage.ProductCode LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.ProductImage
	SET NOCOUNT OFF;
END