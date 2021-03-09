IF OBJECT_ID('[dbo].[sp_Oder_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Oder_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Oder_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.Oder WHERE dbo.Oder.ID = @id
END;