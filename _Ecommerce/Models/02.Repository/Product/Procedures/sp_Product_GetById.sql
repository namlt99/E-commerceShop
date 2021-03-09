IF OBJECT_ID('[dbo].[sp_Product_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Product_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Product_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.Product WHERE dbo.Product.ID = @id
END;