IF OBJECT_ID('[dbo].[sp_GiftCode_Update]') IS NULL
BEGIN
	EXEC ('create procedure [dbo].[sp_GiftCode_Update] as select 1');
END;
GO
ALTER PROC [dbo].[sp_GiftCode_Update]
	@value INT,
	@code VARCHAR(50),
	@startDate DATETIME,
	@endDate DATETIME,
	@modifiedBy VARCHAR(50),
	@modifiedDate DATETIME,
	@status BIT,
	@id bigint
	
AS
BEGIN
	UPDATE dbo.GiftCode
	SET Value = @value, 
		Code =@code,
		StartDate = @startDate,
		EndDate = @endDate,
		ModifiedBy = @modifiedBy,
		ModifiedDate = @modifiedDate,
		Status = @status
	WHERE  ID = @id
END;