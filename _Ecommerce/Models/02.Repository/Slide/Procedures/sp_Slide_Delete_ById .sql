IF OBJECT_ID('[dbo].[sp_Slide_Delete_ById ]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Slide_Delete_ById ] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Slide_Delete_ById]
	@id bigint
	
AS
BEGIN
	DELETE dbo.Slide WHERE dbo.Slide.ID = @id
END;