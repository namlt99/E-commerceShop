IF OBJECT_ID('[dbo].[sp_Slide_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Slide_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Slide_Update]
	@image NVARCHAR(1000),
	@link NVARCHAR(1000),
	@description NVARCHAR(250),
	@modifiedBy VARCHAR(50),
	@modifiedDate DATETIME,
	@status BIT,
	@id BIGINT
	
AS
BEGIN
	UPDATE dbo.Slide
	SET Image = @image,
	    Link =@link,
	    Description =@description,
	    ModifiedBy =@modifiedBy,
	    ModifiedDate =@modifiedDate,
	    Status = @status
	WHERE  ID = @id
END;