IF EXISTS(SELECT name FROM sysobjects
WHERE name = N'usp_GetTemplates'
AND TYPE='P'
)
DROP PROCEDURE usp_GetTemplates
GO

CREATE PROCEDURE usp_GetTemplates

AS

SELECT 
	dbo.uf_Trim(SAS_Template_ID) AS [Template ID]
	, dbo.uf_Trim(SAS_Template_Description) AS [Description]	
FROM SAS00200

GO

GRANT EXECUTE ON usp_GetTemplates TO DYNGRP;

GO