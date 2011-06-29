IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetStudentsPerSubject'
AND TYPE='P'
)
DROP PROCEDURE usp_GetStudentsPerSubject
GO

CREATE PROCEDURE usp_GetStudentsPerSubject
(
	@Item_No AS CHAR(21),
	@Date_From AS DATETIME,
	@Date_To AS DATETIME
)

AS

--EXEC sp_refreshview uv_EnrolledSubjects

--SELECT * 
--FROM dbo.uv_EnrolledSubjects
--WHERE [Item Number] = @Item_No
--AND [Document Date] BETWEEN @Date_From AND @Date_To
--ORDER BY [Item Number], [Customer Number]

SELECT 
	[SubjectDropped] = 
		(
			CASE WHEN ISNULL(Dropped_Subjects.[Item Number], '') = '' THEN
				0
			ELSE
				1
			END
		)
	, Enrolled_Subjects.* 
	, Dropped_Subjects.[SOP Number] AS [Dropped SOP Number]
	, Dropped_Subjects.[SOP Type] AS [Dropped SOP Type]
	, Dropped_Subjects.[Item Number] AS [Dropped Item Number]
	, Dropped_Subjects.[Item Description] AS [Dropped Item Description]
	, Dropped_Subjects.[Quantity] AS [Dropped Quantity]
	, Dropped_Subjects.[Document Date] AS [Dropped Document Date]
FROM
	(
	SELECT * 
	FROM dbo.uv_EnrolledSubjects
	WHERE [SOP Type] = 3 /*enrolled subjects*/
	AND [Item Number] = @Item_No
	AND [Document Date] BETWEEN @Date_From
	AND @Date_To	
	) Enrolled_Subjects

LEFT JOIN
	(
	SELECT * 
	FROM dbo.uv_EnrolledSubjects
	WHERE [SOP Type] = 4 /*dropped subjects*/
	AND [Item Number] = @Item_No
	AND [Document Date] BETWEEN @Date_From
	AND @Date_To
	) Dropped_Subjects


ON Enrolled_Subjects.[Customer Number] = Dropped_Subjects.[Customer Number]
AND Enrolled_Subjects.[Item Number] = Dropped_Subjects.[Item Number]
AND Enrolled_Subjects.[Quantity] = Dropped_Subjects.[Quantity]
ORDER BY Enrolled_Subjects.[Item Number]
, Enrolled_Subjects.[Customer Number]

GO

GRANT EXECUTE ON usp_GetStudentsPerSubject TO DYNGRP;

GO


--EXEC usp_GetStudentsPerSubject @Item_No ='IDN-SISC-20--0001', @Date_From='2011-04-26', @Date_To='2020-04-26'