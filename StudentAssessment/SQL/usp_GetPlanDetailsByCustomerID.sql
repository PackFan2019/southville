IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_GetPlanDetailsByCustomerID'
AND TYPE = 'P'
)
DROP PROCEDURE usp_GetPlanDetailsByCustomerID
GO

CREATE PROCEDURE usp_GetPlanDetailsByCustomerID
(
	@CustomerID AS CHAR(15)
)

AS

SELECT
	RVLSP004.CUSTNMBR AS [Customer Number]
	, RVLSP004.PMNTSCHLDID AS [Instalment Schedule ID]
	, RVLSP004.PAYDAY_1 AS [Payday]
	, RVLSP002.DSCRIPTN AS [Description]
	, RVLSP002.NUMPMNT AS [Number of Payments]
	, RVLSP002.DAYS1STP AS [Days to First Instalment]
	, RVLSP002.CADENCE AS [Cadence]
FROM RVLSP004

LEFT JOIN RVLSP002
ON RVLSP004.PMNTSCHLDID = RVLSP002.PMNTSCHLDID

WHERE

RVLSP004.CUSTNMBR = @CustomerID


GO

GRANT EXECUTE ON usp_GetPlanDetailsByCustomerID TO DYNGRP;

GO