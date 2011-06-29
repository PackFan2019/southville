IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_GetAssessmentItems'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessmentItems
GO

CREATE PROCEDURE usp_GetAssessmentItems
(
	@SOPType AS SMALLINT,
	@Assessment_No AS CHAR(21)
)

AS

SELECT
	 dbo.uf_Trim(SISC10200.[ITEMNMBR]) AS [Item Number]
	, SISC10200.[LNITMSEQ] AS [Item Sequence]
	, dbo.uf_Trim(SISC10200.[ITEMDESC]) AS [Item Description]
	, SISC10200.[UOFM] AS [U of M]
	, SISC10200.[QUANTITY] AS [Quantity]
	, SISC10200.[UNITPRCE] AS [Unit Price]
	, SISC10200.[MARKDOWN] AS [Markdown]
	, SISC10200.[EXTNDPRC] AS [Extended Price]
	, dbo.uf_Trim(IV00101.[ITMCLSCD]) AS [Item Class]
	, dbo.uf_Trim(IV00101.[PriceGroup]) AS [Price Group]
FROM SISC10200 

LEFT JOIN IV00101
	ON IV00101.[ITEMNMBR]=SISC10200.[ITEMNMBR]

WHERE [ASSESSNO] = @Assessment_No
AND [SOPType] = @SOPType

ORDER BY [Item Sequence]


GO

GRANT EXECUTE ON usp_GetAssessmentItems TO DYNGRP;

GO