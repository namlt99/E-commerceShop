IF OBJECT_ID('[dbo].[sp_Product_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Product_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Product_Insert]
	@productName NVARCHAR(255),
	@productCode NVARCHAR(50),
	@productMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@image NVARCHAR(1000),
	@price decimal(21, 0),
	@detail ntext,
	@quantity INT,
	@createdBy VARCHAR(255),
	@status BIT,
	@categoryId BIGINT
	
AS
BEGIN
	INSERT INTO dbo.Product
	        ( ProductName ,
			  ProductCode,
	          ProductMetaTitle ,
	          SeoTitle ,
			  Image,
			  Price,
			  Detail,
			  Quantity,
	          CreatedBy ,
	          Status ,
			  CategoryId
	        )
	VALUES  ( 
				@productName ,
				@productCode ,
				@productMetaTitle ,
				@seoTitle ,
				@image ,
				@price ,
				@detail ,
				@quantity ,
				@createdBy ,
				@status ,
				@categoryId 
	        )
END;