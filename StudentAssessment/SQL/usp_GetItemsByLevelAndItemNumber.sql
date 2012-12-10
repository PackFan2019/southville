IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_GetItemsByLevelAndItemNumber'
AND TYPE='P'
)
DROP PROCEDURE usp_GetItemsByLevelAndItemNumber
GO

CREATE PROCEDURE usp_GetItemsByLevelAndItemNumber
(
	@Item_Number AS CHAR(31),
	@Level AS CHAR(11),
	@Currency AS CHAR(15),
	--@Class_ID AS CHAR(11),
	@UofM AS CHAR(9)
)	

AS

BEGIN

SELECT 
	dbo.uf_Trim(Price_List.ITEMNMBR) AS [Item Number]
	, dbo.uf_Trim(Item_Master.ITEMDESC) AS [Item Description]
	, dbo.uf_Trim(Item_Master.ITMCLSCD) AS [Item Class Code]
	, dbo.uf_Trim(Price_List.CURNCYID) AS [Currency ID]
	, dbo.uf_Trim(Price_List.PRCLEVEL) AS [Price Level]
	, dbo.uf_Trim(Price_List.UOFM) AS [U of M]
	, CAST(Price_List.UOMPRICE AS NUMERIC(19,2)) AS [Unit Price]
	, dbo.uf_Trim(Item_Master.PRICMTHD) AS [Price Method]
	, dbo.uf_Trim(Item_Master.PriceGroup) AS [Price Group]
	, dbo.uf_Trim(Item_Master.ITEMTYPE) AS [Item Type]
	
FROM IV00108 AS Price_List

INNER JOIN
(
	SELECT
		ITEMNMBR
		, ITEMDESC
		, ITMCLSCD
		, PRICMTHD
		, ITEMTYPE
		, PriceGroup
	FROM IV00101
	WHERE PRICMTHD = 1 
		AND (ITEMTYPE = 5 OR ITEMTYPE = 3) --20100528
) Item_Master

ON Price_List.ITEMNMBR = Item_Master.ITEMNMBR

WHERE
Price_List.PRCLEVEL = @Level
AND Price_List.CURNCYID = @Currency
AND Price_List.UOFM = @UofM
--AND Item_Master.ITMCLSCD = @Class_ID
AND Item_Master.ITEMNMBR = @Item_Number

END


GO

GRANT EXECUTE ON usp_GetItemsByLevelAndItemNumber TO DYNGRP;

GO