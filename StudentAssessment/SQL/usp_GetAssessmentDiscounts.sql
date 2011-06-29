IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessmentDiscounts'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentDiscounts
GO

CREATE PROCEDURE usp_GetAssessmentDiscounts
--(
--	@Assessment_No AS CHAR(21)
--)
AS

SELECT 
	Asessment_WORK.[ASSESSNO] AS [Assessment No]
	, Asessment_WORK.[SOPTYPE] AS [SOP Type]
	, dbo.uf_Trim(Discounts_WORK.[DISCNTID]) AS [Discount ID]
	, dbo.uf_Trim(Discounts_MSTR.[SAS_Discount_Description]) AS [Discount Description]
	, Discounts_WORK.[LNITMSEQ] AS [Discount Sequence]
	, Discounts_WORK.[PERCENT] AS [Percent]
	, Discounts_WORK.[DISCAMNT] AS [Discount Amount]
	, dbo.uf_Trim(Discounts_WORK.[APPLIED]) AS [Applied To]

FROM SISC10100 Asessment_WORK

LEFT JOIN SISC10300 Discounts_WORK
ON Asessment_WORK.[ASSESSNO] = Discounts_WORK.[ASSESSNO]
AND Asessment_WORK.[SOPTYPE] = Discounts_WORK.[SOPTYPE]

LEFT JOIN SAS00100 Discounts_MSTR
ON Discounts_WORK.[DISCNTID] = Discounts_MSTR.[SAS_Discount_ID]

ORDER BY Discounts_WORK.[LNITMSEQ]

--WHERE Asessment_WORK.[ASSESSNO]=@Assessment_No
--SELECT * FROM uv_GetAssessments

--SELECT * FROM SAS00100


GO

GRANT EXECUTE ON usp_GetAssessmentDiscounts TO DYNGRP;

GO