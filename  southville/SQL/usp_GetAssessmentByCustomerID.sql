IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessmentByCustomerID'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentByCustomerID
GO

CREATE PROCEDURE usp_GetAssessmentByCustomerID
(
	@Customer_ID AS CHAR(15)
)
AS

SELECT 
	dbo.uf_Trim([ASSESSNO]) AS [Assessment No]
	, dbo.uf_Trim([SOPTYPE]) AS [SOP Type]
	, dbo.uf_Trim([CUSTNMBR]) AS [Student No]
	, dbo.uf_Trim([CUSTNAME]) AS [Student Name]
	, dbo.uf_Trim([LEVEL]) AS [Level]
	, dbo.uf_Trim([GRADELVL]) AS [Grade Level]
	, dbo.uf_Trim([CURNCYID]) AS [Currency]
	, dbo.uf_Trim([BACHNUMB]) AS [Batch No]
	, [DOCDATE] AS [Document Date]
	, dbo.uf_Trim([PLAN]) AS [Plan]
	, [SCHLYRFR] AS [SY From]
	, [SCHLYRTO] AS [SY TO]
	, [TOTLFEES] AS [Total Fees]
	, [TOTLDISC] AS [Total Discounts]
	, [TOTLAMNT] AS [Total Amount]
	, [COMMENTS] AS [Comments]
	, dbo.uf_Trim([SOPNUMBE]) AS [SOP Number]
	, [INSTLFEE] AS [Installment Fee]
	, [RESRVFEE] AS [Reservation Fee]

FROM SISC10100 

WHERE [CUSTNMBR] = @Customer_ID

ORDER BY [DOCDATE] DESC, [ASSESSNO] DESC

GO

GRANT EXECUTE ON usp_GetAssessmentByCustomerID TO DYNGRP;

GO