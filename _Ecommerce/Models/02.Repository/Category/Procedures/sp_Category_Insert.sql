IF OBJECT_ID('[dbo].[sp_Category_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Category_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Category_Insert]
	@categoryName NVARCHAR(255),
	@categoryMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@createdBy VARCHAR(255),
	@status BIT,
	@productGroupId bigint
	
AS
BEGIN
	INSERT INTO dbo.Category
	        ( CategoryName ,
	          CategoryMetaTitle ,
	          SeoTitle ,
	          CreatedBy ,
	          Status,
			  ProductGroupId
	        )
	VALUES  ( 
				@categoryName,
				@categoryMetaTitle,
				@seoTitle,
				@createdBy,
				@status,
				@productGroupId
	        )
END;