IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessmentDiscountsByDocID'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentDiscountsByDocID
GO

CREATE PROCEDURE usp_GetAssessmentDiscountsByDocID
(
	@Assessment_No AS CHAR(21),
	@SOPType AS SMALLINT
)
AS

SELECT 
	dbo.uf_Trim(Asessment_WORK.[ASSESSNO]) AS [Assessment No]
	, Asessment_WORK.[SOPTYPE] AS [SOP Type]
	, dbo.uf_Trim(Discounts_WORK.[DISCNTID]) AS [Discount ID]
	, dbo.uf_Trim(Discounts_MSTR.[SAS_Discount_Description]) AS [Discount Description]
	, Discounts_MSTR.[SAS_Discount_Editable] AS [Discount Type]
	, Discounts_WORK.[LNITMSEQ] AS [Discount Sequence]
	, Discounts_WORK.[PERCENT] AS [Percent]
	, Discounts_WORK.[DISCAMNT] AS [Discount Amount]
	, dbo.uf_Trim(Discounts_WORK.[APPLIED]) AS [Applied To]

FROM SISC10100 Asessment_WORK

INNER JOIN SISC10300 Discounts_WORK
ON Asessment_WORK.[ASSESSNO] = Discounts_WORK.[ASSESSNO]
AND Asessment_WORK.[SOPTYPE] = Discounts_WORK.[SOPTYPE]

INNER JOIN SAS00100 Discounts_MSTR
ON Discounts_WORK.[DISCNTID] = Discounts_MSTR.[SAS_Discount_ID]

WHERE Asessment_WORK.[ASSESSNO]=@Assessment_No
AND Asessment_WORK.[SOPTYPE] = @SOPType 
AND ISNULL(Discounts_WORK.[DISCNTID],'')<>''

ORDER BY Discounts_WORK.[LNITMSEQ]


--SELECT * FROM uv_GetAssessments

--SELECT * FROM SAS00100

--EXEC usp_GetAssessmentDiscountsByDocID 'STDINV3173' , 3

--SELECT * FROM SISC10300

GO

GRANT EXECUTE ON usp_GetAssessmentDiscountsByDocID TO DYNGRP;

GO