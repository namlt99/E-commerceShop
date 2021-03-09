IF OBJECT_ID('[dbo].[sp_Contact_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Contact_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Contact_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.Contact WHERE dbo.Contact.ID = @id
END;