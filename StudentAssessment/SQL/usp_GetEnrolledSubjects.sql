IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetEnrolledSubjects'
AND TYPE='P'
)
DROP PROCEDURE usp_GetEnrolledSubjects
GO

CREATE PROCEDURE usp_GetEnrolledSubjects
(
	@Customer_No AS CHAR(15),
	@Date_From AS DATETIME,
	@Date_To AS DATETIME
)

AS

--EXEC sp_refreshview uv_EnrolledSubjects

SELECT 
	[SubjectDropped] = 
		(
			CASE WHEN [SOP Type] = 3 THEN
				0
			ELSE
				1
			END
		)
	, * 

FROM dbo.uv_EnrolledSubjects

WHERE
[Customer Number] = @Customer_No
AND [Document Date] BETWEEN @Date_From
AND @Date_To	

ORDER BY [Customer Number]
, [Item Number] 


GO

GRANT EXECUTE ON usp_GetEnrolledSubjects TO DYNGRP;

GO

--EXEC usp_GetEnrolledSubjects @Customer_No ='JRPA', @Date_From='2011-04-26', @Date_To='2020-04-26'
