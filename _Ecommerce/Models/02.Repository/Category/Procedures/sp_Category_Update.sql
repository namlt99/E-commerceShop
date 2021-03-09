IF OBJECT_ID('[dbo].[sp_Category_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Category_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Category_Update]
	@categoryName NVARCHAR(255),
	@categoryMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@modifiedBy VARCHAR(255),
	@modifiedDate DATETIME,
	@status BIT,
	@id bigint,
	@productGroupId bigint
	
AS
BEGIN
	UPDATE dbo.Category 
	SET CategoryName = @categoryName, 
		CategoryMetaTitle =@categoryMetaTitle,
		SeoTitle = @seoTitle,
		ModifiedBy = @modifiedBy,
		ModifiedDate = @modifiedDate,
		Status = @status,
		ProductGroupId = @productGroupId
	WHERE  ID = @id
END;