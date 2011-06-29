IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_GetSchoolYear'
AND TYPE = 'P'
)
DROP PROCEDURE usp_GetSchoolYear
GO

CREATE PROCEDURE usp_GetSchoolYear

AS

BEGIN

--SELECT 
--	CAST(UDCOSTR1 AS SMALLINT) AS [School Year From]
--	, CAST(UDCOSTR2 AS SMALLINT) AS [School Year To]
--FROM DYNAMICS..SY01500
--WHERE DB_NAME() = INTERID

SELECT TOP 1
[School Year From] = YEAR(H.FSTFSCDY) --get year from first day of current fiscal year
, [School Year To] = YEAR(H.LSTFSCDY) --get year from last day of current fiscal year
FROM SY40101 H
WHERE GETDATE() between H.FSTFSCDY and H.LSTFSCDY

END

GO

GRANT EXECUTE ON usp_GetSchoolYear TO DYNGRP;

GO




