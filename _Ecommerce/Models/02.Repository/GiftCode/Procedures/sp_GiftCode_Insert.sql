IF OBJECT_ID('[dbo].[sp_GiftCode_Insert]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_GiftCode_Insert] as select 1');
END;
GO
ALTER PROC [dbo].[sp_GiftCode_Insert]
	@value INT,
	@code VARCHAR(50),
	@startDate DATETIME,
	@endDate DATETIME,
	@createdBy VARCHAR(50),
	@status BIT
	
AS
BEGIN
	INSERT INTO dbo.GiftCode
	        ( Value ,
	          Code ,
	          StartDate ,
	          EndDate ,
			  CreatedBy,
	          Status 
	        )
	VALUES  ( 
				@value,
				@code ,
				@startDate ,
				@endDate ,
				@createdBy ,
				@status
	        )
END;