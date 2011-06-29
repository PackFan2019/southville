IF EXISTS(SELECT name FROM sysobjects
WHERE NAME=N'usp_GetPlanBreakdown'
AND TYPE='P'
)
DROP PROCEDURE usp_GetPlanBreakdown
GO

CREATE PROCEDURE usp_GetPlanBreakdown
(
@Plan_ID AS CHAR(15)
)

AS

SELECT
	dbo.uf_Trim(SAS_Installment_ID) AS [Plan ID]
	, SEQNUMBR AS [Sequence] 
	, SAS_Due_Date AS [Due Date]
	, SAS_Percentage AS [Percentage]	

FROM SAS00301
WHERE SAS_Installment_ID = @Plan_ID

ORDER BY SEQNUMBR ASC

GO

GRANT EXECUTE ON usp_GetPlanBreakdown TO DYNGRP;

GO