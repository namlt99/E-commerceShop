IF OBJECT_ID('[dbo].[sp_ProductGroup_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductGroup_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductGroup_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.ProductGroup WHERE dbo.ProductGroup.ID = @id
END;