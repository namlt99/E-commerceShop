IF OBJECT_ID('[dbo].[sp_GiftCode_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_GiftCode_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_GiftCode_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.GiftCode WHERE dbo.GiftCode.Code LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.GiftCode
	SET NOCOUNT OFF;
END