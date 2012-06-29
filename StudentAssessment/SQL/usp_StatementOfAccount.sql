SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('usp_StatementOfAccount','P') IS NOT NULL
	DROP PROCEDURE usp_StatementOfAccount
GO

CREATE PROCEDURE [dbo].[usp_StatementOfAccount]
(
	@CustomerID AS [char](15)
)

AS

DECLARE @LatestAssessment [char](21)
DECLARE @LatestAssessmentInvoiceNo [char](21)
DECLARE @LatestAssessmentDocDate DATETIME
DECLARE @PlanID [char](15)
DECLARE @PlanDescription [char](31)
DECLARE @AccountNo [char](15)
DECLARE @StudentName [char](65)
DECLARE @StudentLevel [char](11)
DECLARE @BeginningBalance [numeric](19,6)
DECLARE @UponEnrollment [numeric](19,6)
DECLARE @UponEnrollmentInvoiceNo [char](21)
DECLARE @UponEnrollmentPaymentNo [char](21)
DECLARE @UponEnrollmentPaymentDocDate DATETIME
DECLARE @TuitionAndMiscFees [numeric](19,6)
DECLARE @AdditionalTuition [numeric](19,6)
DECLARE @OtherFees [numeric](19,6)
DECLARE @SchoolYearFrom [smallint]
DECLARE @SchoolYearTo [smallint]

SET @BeginningBalance = 0
SET @UponEnrollment = 0
SET @TuitionAndMiscFees = 0
SET @AdditionalTuition = 0
SET @OtherFees = 0

SET @StudentName =
(SELECT CUSTNAME FROM RM00101
WHERE CUSTNMBR = @CustomerID)

SET @SchoolYearFrom = 
(SELECT YEAR(H.FSTFSCDY) FROM SY40101 H
WHERE GETDATE() between H.FSTFSCDY and H.LSTFSCDY)

SET @SchoolYearTo = 
(SELECT YEAR(H.LSTFSCDY)FROM SY40101 H
WHERE GETDATE() between H.FSTFSCDY and H.LSTFSCDY)

SET @LatestAssessment = 
(SELECT TOP 1 ASSESSNO 
FROM SISC10100 assessHdr
INNER JOIN SOP30200 sopHdrHist
ON sopHdrHist.ORIGNUMB = assessHdr.ASSESSNO
AND sopHdrHist.SOPTYPE = 3
AND sopHdrHist.ORIGTYPE = 1
WHERE assessHdr.SOPTYPE = 1 
AND sopHdrHist.VOIDSTTS = 0 ORDER BY assessHdr.DOCDATE DESC)

SET @LatestAssessmentInvoiceNo = 
(SELECT SOPNUMBE FROM SOP30200
WHERE SOPTYPE = 3 AND ORIGNUMB = @LatestAssessment AND ORIGTYPE = 1
AND VOIDSTTS = 0)

SET @LatestAssessmentDocDate = 
(SELECT DOCDATE FROM SISC10100 
WHERE SOPTYPE = 1 AND ASSESSNO = @LatestAssessment)

SET @PlanID = 
(SELECT [PLAN] FROM SISC10100 
WHERE SOPTYPE = 1 AND ASSESSNO = @LatestAssessment)

SET @PlanDescription = 
(SELECT DSCRIPTN FROM RVLSP002 
WHERE PMNTSCHLDID = @PlanID)

SET @StudentLevel = 
(SELECT [Level] FROM STUDENTINFO
WHERE [CUSTNMBR] = @CustomerID)

SET @BeginningBalance = 
(SELECT SUM(
CASE WHEN rmOpen.RMDTYPAL = 8 THEN (-rmOpen.CURTRXAM) /*return*/
WHEN rmOpen.RMDTYPAL = 1 THEN (rmOpen.CURTRXAM) END)
FROM RM20101 rmOpen
WHERE rmOpen.RMDTYPAL IN (1,8)
AND rmOpen.VOIDSTTS = 0
AND rmOpen.CUSTNMBR = @CustomerID
AND rmOpen.DOCDATE <= LEFT(CONVERT(VARCHAR(30),@LatestAssessmentDocDate,120),10)
AND rmOpen.DOCNUMBR
NOT IN
(SELECT DOCNUMBR FROM RM20101 rmOpen2
--INNER JOIN SISC10100 assessHdr
--ON rmOpen2.RMDTYPAL = 1
WHERE rmOpen2.RMDTYPAL = 1
AND rmOpen2.CUSTNMBR = @CustomerID
AND rmOpen2.TRXDSCRN = @LatestAssessmentInvoiceNo))
PRINT @LatestAssessmentDocDate
PRINT @BeginningBalance

SET @UponEnrollmentInvoiceNo =
(SELECT TOP 1 DOCNUMBR FROM RVLSP014 WHERE CUSTNMBR = @CustomerID
AND RMDTYPAL = 1 AND DOCNOMAS = @LatestAssessmentInvoiceNo AND CATEGORY = 3
ORDER BY DOCNUMBR ASC)

/*get amount applied to upon enrollment trx*/
SET @UponEnrollment = 
(SELECT (ORTRXAMT - CURTRXAM) 
FROM RM20101
WHERE DOCNUMBR = @UponEnrollmentInvoiceNo
AND RMDTYPAL = 1)

SET @UponEnrollmentPaymentNo =
(SELECT TOP 1 apply.APFRDCNM FROM 
(SELECT APFRDCNM, APTODCNM FROM RM30201 
WHERE CUSTNMBR = @CustomerID
UNION SELECT APFRDCNM, APTODCNM FROM RM20201
WHERE CUSTNMBR = @CustomerID
) apply
WHERE apply.APTODCNM = @UponEnrollmentInvoiceNo)

SET @UponEnrollmentPaymentDocDate =
(SELECT TOP 1 apply.APFRDCDT FROM 
(SELECT APFRDCNM, APFRDCDT FROM RM30201 
WHERE CUSTNMBR = @CustomerID
UNION SELECT APFRDCNM, APFRDCDT FROM RM20201
WHERE CUSTNMBR = @CustomerID) apply
WHERE apply.APFRDCNM = @UponEnrollmentPaymentNo)

SET @TuitionAndMiscFees = 
(SELECT SUM(sopDtlHist.XTNDPRCE)
FROM SOP30200 sopHdrHist
INNER JOIN SOP30300 sopDtlHist
ON sopHdrHist.SOPTYPE = sopDtlHist.SOPTYPE
AND sopHdrHist.SOPNUMBE = sopDtlHist.SOPNUMBE
LEFT JOIN IV00101 itemMstr
ON sopDtlHist.ITEMNMBR = itemMstr.ITEMNMBR
WHERE sopHdrHist.ORIGNUMB = @LatestAssessment
AND sopHdrHist.ORIGTYPE = 1
AND itemMstr.ITMCLSCD IN ('TF','MF','MF-O')
AND sopHdrHist.VOIDSTTS = 0)

SET @OtherFees = 
(SELECT DOCAMNT - @TuitionAndMiscFees
FROM SOP30200 sopHdrHist
WHERE sopHdrHist.ORIGNUMB = @LatestAssessment
AND sopHdrHist.ORIGTYPE = 1
AND sopHdrHist.VOIDSTTS = 0)

SET @AdditionalTuition = 
(SELECT SUM(CASE WHEN sopHdrHist.SOPTYPE = 4 THEN (-sopHdrHist.DOCAMNT) /*drop*/
WHEN sopHdrHist.SOPTYPE = 3 THEN (sopHdrHist.DOCAMNT) END) /*add*/
FROM SOP30200 sopHdrHist
--LEFT JOIN IV00101 itemMstr
--ON sopDtlHist.ITEMNMBR = itemMstr.ITEMNMBR
WHERE sopHdrHist.DOCDATE > LEFT(CONVERT(VARCHAR(30),@LatestAssessmentDocDate,120),10)
AND sopHdrHist.SOPTYPE IN (3, 4)
AND sopHdrHist.VOIDSTTS = 0)

SELECT 
[Student No] = @CustomerID
, [Account No] = ISNULL(@AccountNo, '')
, [Beginning Balance] = ISNULL(@BeginningBalance, 0)
, [Latest Assessment] = ISNULL(@LatestAssessment, '')
, [Latest Assessment Invoice No] = @LatestAssessmentInvoiceNo
, [Latest Assessment Document Date] = ISNULL(@LatestAssessmentDocDate, 0)
, [Plan ID] = ISNULL(@PlanID, '')
, [Plan Description] = ISNULL(@PlanDescription, '')
, [Student Name] = ISNULL(@StudentName, '')
, [Student Level] = ISNULL(@StudentLevel, '')
, [Upon Enrollment Payment] = ISNULL(@UponEnrollment, 0)
, [Upon Enrollment Payment No] = ISNULL(@UponEnrollmentPaymentNo, '')
, [Upon Enrollment Payment Doc Date] = ISNULL(@UponEnrollmentPaymentDocDate, 0)
, [Tuition And Misc Fees] = ISNULL(@TuitionAndMiscFees, 0)
, [Additional Tuition] = ISNULL(@AdditionalTuition, 0)
, [Other Fees] = ISNULL(@OtherFees, 0)
, [School Year From] = ISNULL(@SchoolYearFrom, 0)
, [School Year To] = ISNULL(@SchoolYearTo, 0)

GO

GRANT EXECUTE ON usp_StatementOfAccount TO DYNGRP

GO

--EXEC [usp_StatementOfAccount] '11-0001'

--SELECT * FROM SISC10100
--SELECT * FROM RM20101
--WHERE DOCNUMBR = '000004'



--SELECT rmOpen.*
--FROM RM20101 rmOpen
--WHERE rmOpen.RMDTYPAL IN (1,8)
--AND rmOpen.VOIDSTTS = 0
--AND rmOpen.CUSTNMBR = '11-0001'
--AND rmOpen.DOCDATE <= LEFT(CONVERT(VARCHAR(30),'2012-06-29 17:03:46.993',120),10)
--AND rmOpen.DOCNUMBR
--NOT IN
--(SELECT DOCNUMBR FROM RM20101 rmOpen2
----INNER JOIN SISC10100 assessHdr
----ON rmOpen2.RMDTYPAL = 1
--WHERE rmOpen2.RMDTYPAL = 1
--AND rmOpen2.CUSTNMBR = '11-0001'
--AND rmOpen2.TRXDSCRN = '000015')