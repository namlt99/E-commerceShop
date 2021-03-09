IF OBJECT_ID('[dbo].[sp_ProductImage_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductImage_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductImage_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.ProductImage WHERE dbo.ProductImage.ID = @id
END;