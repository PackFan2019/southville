IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessmentHeader'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentHeader
GO

CREATE PROCEDURE usp_GetAssessmentHeader
(
	@Assessment_No AS CHAR(21)
)
AS

SELECT 
	[ASSESSNO] AS [Assessment No]
	, [CUSTNMBR] AS [Student No]
	, [CUSTNAME] AS [Student Name]
	, [LEVEL] AS [Level]
	, [CURNCYID] AS [Currency]
	, [BACHNUMB] AS [Batch No]
	, [DOCDATE] AS [Document Date]
	, [PLAN] AS [Plan]
	, [SCHLYRFR] AS [SY From]
	, [SCHLYRTO] AS [SY TO]
	, [TOTLFEES] AS [Total Fees]
	, [TOTLDISC] AS [Total Discounts]
	, [TOTLAMNT] AS [Total Amount]
	, [SOPNUMBE] AS [SOP Number]
	, [INSTLFEE] AS [Installment Fee]
	, [RESRVFEE] AS [Reservation Fee]

FROM SISC10100 

WHERE [ASSESSNO] = @Assessment_No

GO

GRANT EXECUTE ON usp_GetAssessmentHeader TO DYNGRP;

GO