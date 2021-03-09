IF OBJECT_ID('[dbo].[sp_ProductImage_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_ProductImage_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_ProductImage_Insert]
	@productCode NVARCHAR(50),
	@fileName NVARCHAR(2000),
	@filePhysicalName NVARCHAR(2000),
	@isMainImage INT
	
AS
BEGIN
	INSERT INTO dbo.ProductImage
	        ( ProductCode,
	          FileName ,
	          FilePhysicalName ,
			  IsMainImage
	        )
	VALUES  ( 
				@productCode ,
				@fileName ,
				@filePhysicalName,
				@isMainImage 
	        )
END;