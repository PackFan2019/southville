IF EXISTS(SELECT name FROM sysobjects
WHERE name=N'usp_ValidateDiscount'
and type='P'
)
DROP PROCEDURE usp_ValidateDiscount
GO

CREATE PROCEDURE usp_ValidateDiscount
(
@DiscountID CHAR(15)
, @StudentNo CHAR(15) --Get the student no for other validations
, @Date DATETIME
)

AS

BEGIN

DECLARE @Result AS INT
DECLARE @StartDate AS DATETIME
DECLARE @EndDate AS DATETIME
DECLARE @Validity AS INT

SET @Validity = CAST(
	(
		SELECT SAS_Discount_Validity 
		FROM SAS00100
		WHERE
		SAS_Discount_ID = @DiscountID
	) AS INT)

IF @Validity=0
BEGIN
	SET @Result=0
END
ELSE
	BEGIN

		SET @StartDate = CAST((SELECT STRTDATE FROM SAS00100 
				WHERE SAS_Discount_ID = @DiscountID) AS DATETIME)
		SET @EndDate = CAST((SELECT ENDDATE FROM SAS00100 
				WHERE SAS_Discount_ID = @DiscountID) AS DATETIME)

		IF @Date>=@StartDate AND @Date<=@EndDate
			SET @Result=0
		ELSE
			SET @Result=1
	END

SELECT @Result AS [Result]

END

--SELECT * FROM SAS00100

		
GO

GRANT EXECUTE ON usp_ValidateDiscount TO DYNGRP;

GO