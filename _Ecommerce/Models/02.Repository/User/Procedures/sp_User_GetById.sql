IF OBJECT_ID('[dbo].[sp_User_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.[User] WHERE dbo.[User].ID = @id
END;