IF EXISTS(SELECT name FROM sysobjects
WHERE name=N'usp_GetTemplateItems'
AND TYPE='P'
)
DROP PROCEDURE usp_GetTemplateItems
GO

CREATE PROCEDURE usp_GetTemplateItems
(@TemplateID AS CHAR(15))

AS

SELECT 
	dbo.uf_Trim([ITEMNMBR]) AS [Item no]
	, QUANTITY AS [Qty]
FROM SAS00201
WHERE SAS_Template_ID=@TemplateID

GO

GRANT EXECUTE ON usp_GetTemplateItems TO DYNGRP;

GO