IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'uv_EnrolledSubjects'
AND TYPE='V'
)
DROP VIEW uv_EnrolledSubjects
GO

CREATE VIEW uv_EnrolledSubjects

AS

SELECT 
	dbo.uf_Trim(SOP_Line_HIST.[SOPNUMBE]) AS [SOP Number]
	, SOP_Line_HIST.[SOPTYPE] AS [SOP Type]
	, dbo.uf_Trim(SOP_HDR_HIST.[CUSTNMBR]) AS [Customer Number]
	, dbo.uf_Trim(SOP_HDR_HIST.[CUSTNAME]) AS [Customer Name]
	, SOP_Line_HIST.[LNITMSEQ] AS [Item Sequence]
	, ISNULL(dbo.uf_Trim(Item_MSTR.[ITMCLSCD]), '') AS [Item Class Code]
	, dbo.uf_Trim(SOP_Line_HIST.[ITEMNMBR]) AS [Item Number]
	, dbo.uf_Trim(SOP_Line_HIST.[ITEMDESC]) AS [Item Description]
	, SOP_Line_HIST.[QUANTITY] AS [Quantity]
	, SOP_HDR_HIST.[QUOTEDAT] AS [Original Quote Date]
	, [Original Quote Number] = 
		(
		CASE WHEN SOP_HDR_HIST.[SOPTYPE] = 3 AND SOP_HDR_HIST.[ORIGTYPE] = 1 THEN
			dbo.uf_Trim(SOP_HDR_HIST.[ORIGNUMB])
		ELSE
		''
		END
		)
	, SOP_HDR_HIST.[DOCDATE] AS [Document Date]
	
FROM SOP30300 SOP_Line_HIST

LEFT JOIN SOP30200 SOP_HDR_HIST
ON SOP_Line_HIST.[SOPNUMBE] = SOP_HDR_HIST.[SOPNUMBE]
AND SOP_Line_HIST.[SOPTYPE] = SOP_HDR_HIST.[SOPTYPE]

LEFT JOIN IV00101 Item_MSTR
ON SOP_Line_HIST.[ITEMNMBR] = Item_MSTR.[ITEMNMBR]

WHERE 
SOP_Line_HIST.[SOPTYPE] IN (/*1, */3, 4) /*Quote?, Invoice, Return*/
AND SOP_HDR_HIST.[VOIDSTTS] = 0
AND Item_MSTR.[ITMCLSCD] = 'SUBJID'


GO

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON uv_EnrolledSubjects TO DYNGRP;

GO

