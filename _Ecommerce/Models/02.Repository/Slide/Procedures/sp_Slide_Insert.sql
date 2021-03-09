IF OBJECT_ID('[dbo].[sp_Slide_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Slide_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Slide_Insert]
	@image NVARCHAR(1000),
	@link NVARCHAR(1000),
	@description NVARCHAR(250),
	@createdBy DATETIME,
	@status BIT
AS
BEGIN
	INSERT INTO dbo.Slide
	        ( Image ,
	          Link ,
	          Description ,
	          CreatedBy ,
	          Status 
	        )
	VALUES  ( 
				@image ,
				@link ,
				@description ,
				@createdBy ,
				@status 
	        )
END;