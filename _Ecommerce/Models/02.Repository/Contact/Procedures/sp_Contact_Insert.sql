IF OBJECT_ID('[dbo].[sp_Contact_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Contact_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Contact_Insert]
	@content ntext,
	@status bit
	
AS
BEGIN
	INSERT INTO [dbo].[Contact]
	(
		[Content],
		[Status]
	)
	VALUES
	(
		@content,
		@status
	)
END;