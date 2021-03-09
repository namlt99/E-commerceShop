IF OBJECT_ID('[dbo].[sp_Oder_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Oder_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Oder_Insert]
	@userId BIGINT,
	@amount DECIMAL(21,0),
	@shipNote NTEXT,
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