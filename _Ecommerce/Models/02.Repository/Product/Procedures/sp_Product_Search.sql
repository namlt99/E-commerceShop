IF OBJECT_ID('[dbo].[sp_Product_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Product_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Product_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.Product WHERE dbo.Product.ProductName LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.Product
	SET NOCOUNT OFF;
END