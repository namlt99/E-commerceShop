IF OBJECT_ID('[dbo].[sp_Slide_Search]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_Slide_Search] as select 1');
END;
GO
ALTER PROC [dbo].[sp_Slide_Search]
(
	@searchString nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	IF (@searchString IS NOT NULL)
		SELECT * FROM dbo.Slide WHERE dbo.Slide.Description LIKE '%'+@searchString+'%'
	else
		SELECT * FROM dbo.Slide
	SET NOCOUNT OFF;
END