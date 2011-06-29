IF EXISTS(SELECT NAME FROM sysobjects 
WHERE NAME=N'usp_GetInstalmentSchedules'
AND TYPE='P'
)
DROP PROCEDURE usp_GetInstalmentSchedules
GO

CREATE PROCEDURE usp_GetInstalmentSchedules

AS

SELECT 
	dbo.uf_Trim([PMNTSCHLDID]) AS [Plan ID]
	, dbo.uf_Trim(DSCRIPTN) AS [Description]
	, NUMPMNT AS [Number of Payments]
	, DAYS1STP AS [Days from first payment]
	, CADENCE AS [Cadence]
FROM RVLSP002

ORDER BY [PMNTSCHLDID]

GO

GRANT EXECUTE ON usp_GetInstalmentSchedules TO DYNGRP;

GO