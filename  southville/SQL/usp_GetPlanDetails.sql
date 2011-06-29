IF EXISTS(SELECT NAME FROM sysobjects 
WHERE NAME=N'usp_GetPlanDetails'
AND TYPE='P'
)
DROP PROCEDURE usp_GetPlanDetails
GO

CREATE PROCEDURE usp_GetPlanDetails
(
	@Plan_ID AS CHAR(15)
)

AS

SELECT 
	dbo.uf_Trim(RVLSP002.PMNTSCHLDID) AS [Plan ID]
	, dbo.uf_Trim(RVLSP002.DSCRIPTN) AS [Description]
	, RVLSP002.NUMPMNT AS [Number of Payments]
	, RVLSP002.DAYS1STP AS [Days from first payment]
	, RVLSP002.CADENCE AS [Cadence]
	, [Installment Fee Percentage]
	= (CASE WHEN ISNULL(SAS00300.SAS_Installment_Fee_Rate,0)=0
		THEN 0
		ELSE
		SAS00300.SAS_Installment_Fee_Rate
		END)
FROM RVLSP002
LEFT JOIN SAS00300
ON RVLSP002.PMNTSCHLDID = SAS00300.SAS_Installment_ID

WHERE PMNTSCHLDID = @Plan_ID


GO

GRANT EXECUTE ON usp_GetPlanDetails TO DYNGRP;

GO