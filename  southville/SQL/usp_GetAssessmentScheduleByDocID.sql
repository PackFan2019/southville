IF EXISTS(SELECT NAME
FROM sysobjects 
WHERE NAME=N'usp_GetAssessmentScheduleByDocID'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentScheduleByDocID
GO

CREATE PROCEDURE usp_GetAssessmentScheduleByDocID
(
	@AssessmentNo AS CHAR(21),
	@SOPType AS SMALLINT
)

AS


SELECT 
	dbo.uf_Trim(Assessment_WORK.[ASSESSNO]) AS [Assessment No]
	, Assessment_WORK.[SOPTYPE] AS [SOP Type]
	, Assessment_WORK.[DOCDATE] AS [Document Date]
	, Assessment_WORK.[INSTLFEE] AS [Installment Fee]
	, Assessment_WORK.[RESRVFEE] AS [Reservation Fee]
	, PaymentSchedules_WORK.[DUEDATE] AS [Due Date]
	, PaymentSchedules_WORK.[AMOUNT] AS [Amount]

FROM SISC10100 Assessment_WORK

INNER JOIN SISC10400 PaymentSchedules_WORK
ON Assessment_WORK.[ASSESSNO] = PaymentSchedules_WORK.[ASSESSNO]
AND Assessment_WORK.[SOPTYPE] = PaymentSchedules_WORK.[SOPTYPE]

WHERE Assessment_WORK.[ASSESSNO]=@AssessmentNo
AND Assessment_WORK.[SOPTYPE]=@SOPType

GO

GRANT EXECUTE ON usp_GetAssessmentScheduleByDocID TO DYNGRP;

GO