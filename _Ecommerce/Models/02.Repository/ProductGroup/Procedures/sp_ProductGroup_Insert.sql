IF OBJECT_ID('[dbo].[sp_ProductGroup_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductGroup_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductGroup_Insert]
	@productGroupName NVARCHAR(255),
	@productGroupMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@createdBy VARCHAR(255),
	@status BIT
	
AS
BEGIN
	INSERT INTO dbo.ProductGroup
	        ( ProductGroupName ,
	          ProductGroupMetaTitle ,
	          SeoTitle ,
	          CreatedBy ,
	          Status 
	        )
	VALUES  ( 
				@productGroupName,
				@productGroupMetaTitle,
				@seoTitle,
				@createdBy,
				@status 
	        )
END;