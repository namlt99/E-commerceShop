IF OBJECT_ID('[dbo].[sp_User_CheckUser]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_CheckUser] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_CheckUser]
	@email NVARCHAR(250)
AS
BEGIN
	SELECT COUNT(*) FROM dbo.[User] WHERE dbo.[User].Email = @email
END;