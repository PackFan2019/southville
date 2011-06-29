IF EXISTS(SELECT name FROM sysobjects
WHERE name=N'usp_GetKitComponents'
AND TYPE='P')
DROP PROCEDURE usp_GetKitComponents
GO

CREATE PROCEDURE usp_GetKitComponents
(
@Kit AS CHAR(31)
)

AS

SELECT 
	dbo.uf_Trim(Item_Kit_Components.ITEMNMBR) AS [Item No],
	dbo.uf_Trim(Item_Kit_Components.CMPTITNM) AS [Component Item No],
	dbo.uf_Trim(Item_Kit_Components.CMPITUOM) AS [U of M],
	dbo.uf_Trim(Item_Kit_Components.CMPITQTY) AS [Qty],
	dbo.uf_Trim(Item_Master.ITEMTYPE) AS [Item Type]
FROM IV00104 Item_Kit_Components
LEFT JOIN IV00101 Item_Master
	ON dbo.uf_Trim(Item_Kit_Components.CMPTITNM) = dbo.uf_Trim(Item_Master.ITEMNMBR)
WHERE dbo.uf_Trim(Item_Kit_Components.ITEMNMBR) = @Kit
ORDER BY SEQNUMBR ASC


GO

GRANT EXECUTE ON usp_GetKitComponents TO DYNGRP;

GO