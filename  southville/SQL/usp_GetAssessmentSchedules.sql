IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessmentSchedules'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentSchedules
GO

CREATE PROCEDURE usp_GetAssessmentSchedules
--(
--	@Assessment_No AS CHAR(21)
--)
AS

SELECT 
	Assessment_WORK.[ASSESSNO] AS [Assessment No]
	, Assessment_WORK.[SOPTYPE] AS [SOP Type]
	, Assessment_WORK.[DOCDATE] AS [Document Date]
	, Assessment_WORK.[INSTLFEE] AS [Installment Fee]
	, Assessment_WORK.[RESRVFEE] AS [Reservation Fee]
	, PaymentSchedules_WORK.[DUEDATE] AS [Due Date]
	, PaymentSchedules_WORK.[AMOUNT] AS [Amount]

FROM SISC10100 Assessment_WORK

LEFT JOIN SISC10400 PaymentSchedules_WORK
ON Assessment_WORK.[ASSESSNO] = PaymentSchedules_WORK.[ASSESSNO]
AND Assessment_WORK.[SOPTYPE] = PaymentSchedules_WORK.[SOPTYPE]

--WHERE Asessment_WORK.[ASSESSNO]=@Assessment_No
--SELECT * FROM uv_GetAssessments

--SELECT * FROM SISC10400

GO

GRANT EXECUTE ON usp_GetAssessmentSchedules TO DYNGRP;

GO