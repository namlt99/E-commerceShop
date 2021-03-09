IF OBJECT_ID('[dbo].[sp_Contact_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Contact_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Contact_Update]
	@content ntext,
	@status bit,
	@id bigint
	
AS
BEGIN
	UPDATE dbo.Contact SET Content =  @content,Status = @status WHERE ID = @id
END;