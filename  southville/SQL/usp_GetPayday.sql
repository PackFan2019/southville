IF EXISTS (SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetPayday'
AND TYPE = 'P'
)
DROP PROCEDURE usp_GetPayday
GO

CREATE PROCEDURE usp_GetPayday
(
	@Customer_ID AS CHAR(15),
	@PaydayNo AS INT
)

AS

SELECT 
	dbo.uf_Trim([CUSTNMBR]) AS [Customer ID],
	[Payday] = (
				CASE WHEN @PaydayNo = 1 THEN [PAYDAY_1]
				WHEN @PaydayNo = 2 THEN [PAYDAY_2]
				WHEN @PaydayNo = 3 THEN [PAYDAY_3]
				WHEN @PaydayNo = 4 THEN [PAYDAY_4]
				END
				)

FROM RVLSP004
WHERE CUSTNMBR = @Customer_ID

--SELECT * FROM RVLSP004

--EXEC usp_GetPayday 'AMERICAN0001',2

GO

GRANT EXECUTE ON usp_GetPayday TO DYNGRP;

GO