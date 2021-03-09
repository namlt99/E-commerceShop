IF OBJECT_ID('[dbo].[sp_ProductGroup_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductGroup_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductGroup_Update]
	@productGroupName NVARCHAR(255),
	@productGroupMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@modifiedBy VARCHAR(255),
	@modifiedDate DATETIME,
	@status BIT,
	@id bigint
	
AS
BEGIN
	UPDATE dbo.ProductGroup 
	SET ProductGroupName = @productGroupName, 
		ProductGroupMetaTitle =@productGroupMetaTitle,
		SeoTitle = @seoTitle,
		ModifiedBy = @modifiedBy,
		ModifiedDate = @modifiedDate,
		Status = @status
	WHERE  ID = @id
END;