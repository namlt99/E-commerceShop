IF OBJECT_ID('[dbo].[sp_User_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_User_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_User_Insert]
	@firstName NVARCHAR(50),
	@middleName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@email NVARCHAR(250),
	@password VARCHAR(50),
	@codeConfirm VARCHAR(50),
	@dateOfBirth DATE,
	@address NVARCHAR(250),
	@avatar NVARCHAR(500),
	@status BIT,
	@gender INT,
	@numberPhone VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.[User]
	        ( FirstName ,
			  MiddleName,
	          LastName ,
	          Email ,
			  Password,
			  CodeConfirm,
			  DateOfBirth,
			  Address,
	          Avatar ,
	          Status ,
			  Gender,
			  Numberphone
	        )
	VALUES  ( 
				@firstName,
				@middleName,
				@lastName,
				@email ,
				@password ,
				@codeConfirm ,
				@dateOfBirth ,
				@address ,
				@avatar ,
				@status ,
				@gender ,
				@numberPhone 
	        )
END;