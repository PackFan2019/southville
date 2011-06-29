IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_InsertAssessmentPaymentDetail'
AND TYPE='P'
)
DROP PROCEDURE usp_InsertAssessmentPaymentDetail
GO

CREATE PROCEDURE usp_InsertAssessmentPaymentDetail
(
@SOPType AS SMALLINT,
@AssessmentNo AS CHAR(21),
@DueDate AS SMALLDATETIME,
@Amount NUMERIC(19,5)
)

AS

INSERT INTO SISC10400
VALUES
(
@SOPType,
@AssessmentNo,
@DueDate,
@Amount
)

--select * from SISC10400
--usp_InsertAssessmentPaymentDetail 1, 

GO

GRANT EXECUTE ON usp_InsertAssessmentPaymentDetail TO DYNGRP;

GO