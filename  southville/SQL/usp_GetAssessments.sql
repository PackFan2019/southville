IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetAssessments'
AND TYPE='P'
)
DROP PROCEDURE usp_GetAssessments
GO

CREATE PROCEDURE usp_GetAssessments
(
	@Assessment_No AS CHAR(21),
	@SOP_Type AS SMALLINT
)

AS

--EXEC sp_refreshview uv_GetAssessments

SELECT * 
FROM dbo.uv_GetAssessments
WHERE [Assessment No]=@Assessment_No
AND [SOP Type]=@SOP_Type
ORDER BY [Item Sequence]

GO

GRANT EXECUTE ON usp_GetAssessments TO DYNGRP;

GO