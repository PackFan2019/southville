IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_InsertAssessmentLine'
AND TYPE='P'
)
DROP PROCEDURE usp_InsertAssessmentLine
GO

CREATE PROCEDURE usp_InsertAssessmentLine
(
@SOPType AS SMALLINT,
@AssessmentNo AS CHAR(21),
@Sequence AS INT,
@ItemNumber AS CHAR(31),
@ItemDescription AS CHAR(101),
@UofM AS CHAR(9),
@Quantity AS NUMERIC(19,5),
@UnitPrice AS NUMERIC(19,5),
@Markdown AS NUMERIC(19,5),
@ExtendedPrice AS NUMERIC(19,5)
)

AS

BEGIN TRANSACTION

INSERT INTO SISC10200
VALUES
(
@SOPType,
@AssessmentNo,
@Sequence,
@ItemNumber,
@ItemDescription,
@UofM,
@Quantity,
@UnitPrice,
@Markdown,
@ExtendedPrice
)

COMMIT TRANSACTION

IF @@ERROR <> 0 
BEGIN
	ROLLBACK TRANSACTION
END


GO

GRANT EXECUTE ON usp_InsertAssessmentLine TO DYNGRP;

GO