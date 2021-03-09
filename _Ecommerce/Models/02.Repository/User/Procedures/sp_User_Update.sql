IF OBJECT_ID('[dbo].[sp_User_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Update]
	@firstName NVARCHAR(50),
	@middleName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@password VARCHAR(50),
	@dateOfBirth DATE,
	@address NVARCHAR(250),
	@avatar NVARCHAR(500),
	@status BIT,
	@level INT,
	@gender INT,
	@numberPhone VARCHAR(50),
	@id BIGINT
	
AS
BEGIN
	UPDATE dbo.[User] 
	SET FirstName = @firstName,
		MiddleName = @middleName,
		LastName =@lastName,
		Password = @password,
		DateOfBirth = @dateOfBirth,
		Address = @address,
		Avatar = @avatar,
		Status = @status,
		Level = @level,
		Gender = @gender,
		Numberphone = @numberPhone
	WHERE  ID = @id
END;