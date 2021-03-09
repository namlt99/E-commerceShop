IF OBJECT_ID('[dbo].[sp_User_Delete_ById  ]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Delete_ById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Delete_ById]
	@id bigint
AS
BEGIN
	DELETE dbo.[User] WHERE dbo.[User].ID = @id
END;