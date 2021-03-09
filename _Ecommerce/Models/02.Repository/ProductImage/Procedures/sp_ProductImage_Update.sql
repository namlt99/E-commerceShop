IF OBJECT_ID('[dbo].[sp_ProductImage_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductImage_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductImage_Update]
	@productCode NVARCHAR(50),
	@fileName NVARCHAR(2000),
	@filePhysicalName NVARCHAR(2000),
	@isMainImage INT,
	@id BIGINT
AS
BEGIN
	UPDATE dbo.ProductImage
	SET ProductCode = @productCode,
	    FileName = @fileName,
	    FilePhysicalName =@filePhysicalName,
		IsMainImage=@isMainImage
	WHERE ID = @id
END;