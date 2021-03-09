IF OBJECT_ID('[dbo].[sp_Slide_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Slide_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Slide_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.Slide WHERE dbo.Slide.ID = @id
END;