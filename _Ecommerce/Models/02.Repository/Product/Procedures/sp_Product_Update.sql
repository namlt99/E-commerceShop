IF OBJECT_ID('[dbo].[sp_Product_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Product_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Product_Update]
	@productName NVARCHAR(255),
	@productCode NVARCHAR(50),
	@productMetaTitle NVARCHAR(255),
	@seoTitle NVARCHAR(255),
	@image NVARCHAR(1000),
	@price decimal(21, 0),
	@discount INT,
	@detail ntext,
	@quantity INT,
	@topHot DATETIME,
	@modifiedDate DATETIME,
	@modifiedBy VARCHAR(255),
	@status BIT,
	@categoryId BIGINT,
	@id BIGINT
	
AS
BEGIN
	UPDATE dbo.Product 
	SET ProductName = @productName,
		ProductCode = @productCode,
		ProductMetaTitle =@productMetaTitle,
		SeoTitle = @seoTitle,
		Image = @image,
		Price = @price,
		Discount = @discount,
		Detail = @detail,
		Quantity = @quantity,
		ModifiedBy = @modifiedBy,
		ModifiedDate = @modifiedDate,
		Status = @status,
		CategoryId = @categoryId
	WHERE  ID = @id
END;