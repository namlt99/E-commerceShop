IF OBJECT_ID('[dbo].[sp_Product_Delete_ById ]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Product_Delete_ById ] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Product_Delete_ById ]
	@id bigint
AS
BEGIN
	DELETE dbo.Product WHERE dbo.Product.ID = @id
END;