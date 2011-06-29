IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_InsertAssessmentDiscount'
AND TYPE='P'
)
DROP PROCEDURE usp_InsertAssessmentDiscount
GO

CREATE PROCEDURE usp_InsertAssessmentDiscount
(
@SOPType AS SMALLINT,
@AssessmentNo AS CHAR(21),
@Sequence AS INT,
@DiscountID AS CHAR(15),
@Percent AS NUMERIC(19,5),
@DiscountAmount AS NUMERIC(19,5),
@AppliedTo AS CHAR(50)
)

AS

INSERT INTO SISC10300
VALUES
(
@SOPType,
@AssessmentNo,
@Sequence,
@DiscountID,
@Percent,
@DiscountAmount,
@AppliedTo
)

GO

GRANT EXECUTE ON usp_InsertAssessmentDiscount TO DYNGRP;

GO