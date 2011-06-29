IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'uv_GetAssessments'
AND TYPE='V'
)
DROP VIEW uv_GetAssessments
GO

CREATE VIEW uv_GetAssessments

AS

SELECT 
	dbo.uf_Trim(Asessment_WORK.[ASSESSNO]) AS [Assessment No]
	, Asessment_WORK.[SOPTYPE] AS [SOP Type]
	, dbo.uf_Trim(Asessment_WORK.[CUSTNMBR]) AS [Student No]
	, dbo.uf_Trim(Asessment_WORK.[CUSTNAME]) AS [Student Name]
	, dbo.uf_Trim(STUDENTINFO.[LEVEL]) AS [Year Level]
	, dbo.uf_Trim(Asessment_WORK.[LEVEL]) AS [Price Level]
	, dbo.uf_Trim(Asessment_WORK.[CURNCYID]) AS [Currency]
	, dbo.uf_Trim(Asessment_WORK.[BACHNUMB]) AS [Batch No]
	, Asessment_WORK.[DOCDATE] AS [Document Date]
	, dbo.uf_Trim(Asessment_WORK.[PLAN]) AS [Plan]
	, Asessment_WORK.[SCHLYRFR] AS [SY From]
	, Asessment_WORK.[SCHLYRTO] AS [SY TO]
	, Asessment_WORK.[TOTLFEES] AS [Total Fees]
	, Asessment_WORK.[TOTLDISC] AS [Total Discounts]
	, Asessment_WORK.[TOTLAMNT] AS [Total Amount]
	, dbo.uf_Trim(Asessment_WORK.[COMMENTS]) AS [Comments]
	, dbo.uf_Trim(Asessment_WORK.[SOPNUMBE]) AS [SOP Number]
	, Asessment_WORK.[INSTLFEE] AS [Installment Fee]
	, Asessment_WORK.[RESRVFEE] AS [Reservation Fee]
	, Item_MSTR.[ITMCLSCD] AS [Item Class Code]
	, Item_MSTR.[PriceGroup] AS [Price Group]
	, dbo.uf_Trim(Asessment_Line_WORK.[ITEMNMBR]) AS [Item Number]
	, Asessment_Line_WORK.[LNITMSEQ] AS [Item Sequence]
	, dbo.uf_Trim(Asessment_Line_WORK.[ITEMDESC]) AS [Item Description]
	, Asessment_Line_WORK.[QUANTITY] AS [Quantity]
	, Asessment_Line_WORK.[UNITPRCE] AS [Unit Price]
	, Asessment_Line_WORK.[MARKDOWN] AS [Markdown Percentage]
	, Asessment_Line_WORK.[EXTNDPRC] AS [Extended Price]
	--, Discounts_WORK.[DISCNTID] AS [Discount ID]
	--, Discounts_WORK.[LNITMSEQ] AS [Discount Sequence]
	--, Discounts_WORK.[DISCAMNT] AS [Discount Amount]

FROM SISC10100 Asessment_WORK

LEFT JOIN SISC10200 Asessment_Line_WORK
ON Asessment_WORK.[ASSESSNO] = Asessment_Line_WORK.[ASSESSNO]
AND Asessment_WORK.[SOPTYPE] = Asessment_Line_WORK.[SOPTYPE]

LEFT JOIN IV00101 Item_MSTR
ON Asessment_Line_WORK.[ITEMNMBR] = Item_MSTR.[ITEMNMBR]

LEFT JOIN STUDENTINFO
ON Asessment_WORK.[CUSTNMBR] = STUDENTINFO.[CUSTNMBR]

--LEFT JOIN SISC10300 Discounts_WORK
--ON Asessment_WORK.[ASSESSNO] = Discounts_WORK.[ASSESSNO]

--SELECT * FROM uv_GetAssessments


GO

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON uv_GetAssessments TO DYNGRP;

GO