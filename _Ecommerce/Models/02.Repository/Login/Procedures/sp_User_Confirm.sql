IF OBJECT_ID('[dbo].[sp_User_Confirm]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Confirm] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Confirm]
	@codeConfirm BIGINT,
	@status BIT,
	@id BIGINT
AS
BEGIN
	UPDATE dbo.[User] 
	SET Status = @status
	WHERE  ID = @id AND dbo.[User].CodeConfirm = @codeConfirm
END;