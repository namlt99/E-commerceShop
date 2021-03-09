IF OBJECT_ID('[dbo].[sp_Category_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Category_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Category_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.Category WHERE dbo.Category.ID = @id
END;