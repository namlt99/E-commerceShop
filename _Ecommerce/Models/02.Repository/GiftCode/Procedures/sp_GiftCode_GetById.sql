IF OBJECT_ID('[dbo].[sp_GiftCode_GetById]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_GiftCode_GetById] as select 1');
END;
GO
ALTER PROC [dbo].[sp_GiftCode_GetById]
	@id bigint
	
AS
BEGIN
	SELECT * FROM dbo.GiftCode WHERE dbo.GiftCode.ID = @id
END;