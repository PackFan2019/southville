IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_CreateAssessment'
AND TYPE='P')
DROP PROCEDURE usp_CreateAssessment
GO

CREATE PROCEDURE usp_CreateAssessment
(
@AssessmentNo AS CHAR(21),
@SOPType AS SMALLINT,
@CustomerNo AS CHAR(15),
@CustomerName AS CHAR(65),
@Level AS CHAR(15),
@GradeLevel AS CHAR(255),
@CurrencyID AS CHAR(15),
@BatchID AS CHAR(15),
@DocDate AS DATETIME,
@Plan AS CHAR(6),
@SYFrom AS SMALLINT,
@SYTo AS SMALLINT,
@TotalFees AS NUMERIC(19,5),
@TotalDiscounts AS NUMERIC (19,5),
@TotalAmount AS NUMERIC (19,5),
@Comments AS CHAR(250),
@SOPNumber AS CHAR(21),
@InstallmentFee AS NUMERIC(19,5),
@ReservationFee AS NUMERIC(19,5)
)

AS

BEGIN TRANSACTION

INSERT INTO SISC10100
VALUES
(@AssessmentNo,
@SOPType,
@CustomerNo,
@CustomerName,
@Level,
@GradeLevel,
@CurrencyID,
@BatchID,
@DocDate,
@Plan,
@SYFrom,
@SYTo,
@TotalFees,
@TotalDiscounts,
@TotalAmount,
@Comments,
@SOPNumber,
@InstallmentFee,
@ReservationFee)

INSERT INTO RVLSP007
(SOPNUMBE, SOPTYPE)
VALUES
(@AssessmentNo,
@SOPType) /*Fix: when posting invoice documents scheduled installments is being used*/

COMMIT TRANSACTION

IF @@ERROR <> 0 BEGIN
	ROLLBACK TRANSACTION

END 

GO

GRANT EXECUTE ON usp_CreateAssessment TO DYNGRP;

GO