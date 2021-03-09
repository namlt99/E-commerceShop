IF OBJECT_ID('[dbo].[sp_User_Login]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Login] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Login]
	@email NVARCHAR(250),
	@passWord VARCHAR(250)
AS
BEGIN
	DECLARE @dem INT
	DECLARE @lv INT
	DECLARE @res BIT
	SELECT @dem=COUNT(*) FROM dbo.[User] WHERE Email=@email AND Password=@password AND Status = 1 GROUP BY Level
	IF @dem >0
		SET @res = 1
	ELSE 
		SET @res = 0

	SELECT @res
END;