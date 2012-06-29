SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('usp_StatementOfAccountAmountDues','P') IS NOT NULL
	DROP PROCEDURE usp_StatementOfAccountAmountDues
GO

CREATE PROCEDURE [dbo].[usp_StatementOfAccountAmountDues]
(
	@AssessmentNo AS [char](21)
)

AS

--DECLARE @AdditionalTuition [numeric](19,6)

--SET @AdditionalTuition = 
--(SELECT SUM(CASE WHEN sopDtlHist.SOPTYPE = 4 THEN (-sopDtlHist.XTNDPRCE) /*drop*/
--WHEN sopDtlHist.SOPTYPE = 3 THEN (sopDtlHist.XTNDPRCE) END) /*add*/
--FROM SOP30200 sopHdrHist
--INNER JOIN SOP30300 sopDtlHist
--ON sopHdrHist.SOPTYPE = sopDtlHist.SOPTYPE
--AND sopHdrHist.SOPNUMBE = sopDtlHist.SOPNUMBE
----LEFT JOIN IV00101 itemMstr
----ON sopDtlHist.ITEMNMBR = itemMstr.ITEMNMBR
--WHERE sopHdrHist.DOCDATE = (SELECT DOCDATE FROM SISC10100 
--WHERE SOPTYPE = 1 AND ASSESSNO = @AssessmentNo)
--AND sopHdrHist.SOPTYPE IN (3, 4)
--AND sopHdrHist.VOIDSTTS = 0)

--SET @AdditionalTuition = ISNULL(@AdditionalTuition, 0)

SELECT [Description] = 
(CASE WHEN DUEDATE = 
(SELECT TOP 1 DUEDATE FROM SISC10400 WHERE ASSESSNO = @AssessmentNo ORDER BY DUEDATE ASC)
THEN 'UPON ENROLLMENT'
ELSE 'DUE ' + UPPER(DATENAME(MONTH, DATEADD(MONTH, MONTH(DUEDATE), 0) - 1)) END
)
, [Due Date] = DUEDATE
, [Amount] = AMOUNT
--+ (CASE WHEN GETDATE()<=DUEDATE THEN @AdditionalTuition ELSE 0 END)
--, @AdditionalTuition (CASE WHEN GETDATE()<=DUEDATE THEN @AdditionalTuition ELSE 0 END)
FROM SISC10400
WHERE SOPTYPE = 1
AND ASSESSNO = @AssessmentNo
ORDER BY DUEDATE ASC
GO

GRANT EXECUTE ON usp_StatementOfAccountAmountDues TO DYNGRP

GO


--SELECT * FROM SISC10400

--[usp_StatementOfAccountAmountDues] TQ002    

--UPDATE SISC10400
--SET DUEDATE=DATEADD(YEAR,1,DUEDATE)
--WHERE ASSESSNO='0000021'