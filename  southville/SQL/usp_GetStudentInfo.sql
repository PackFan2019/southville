IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetStudentInfo'
AND TYPE='P'
)
DROP PROCEDURE usp_GetStudentInfo
GO

CREATE PROCEDURE usp_GetStudentInfo
(
	@Student_No AS CHAR(15)
)

AS

EXEC sp_refreshview STUDENTINFO

--do not change the aliases
SELECT 
	CUSTNMBR AS [Customer No]
	, CUSTCLAS AS [Class ID]
	, CUSTNAME AS [Customer Name]
	, CURNCYID AS [Currency ID]
	, PRCLEVEL AS [Price Level]
	, [First name] AS [First Name]
	, [Middle name] AS [Middle Name]
	, [Last name] AS [Last Name]
	, [Level] AS [Level]
	, [Section] AS [Section]
	, [Gender] AS [Gender]
	, [Officially Enrolled] AS [Status]
	, [Nationality] AS [Nationality]
	, [Place of Birth] AS [Place of Birth]
	, [Email Address] AS [Email Address]
	, [Birthday] AS [Birthday]
	, [Last School Attended] AS [Last School Attended]
	, [Religion] AS [Religion]

FROM STUDENTINFO

WHERE
	CUSTNMBR = @Student_No

GO

GRANT EXECUTE ON usp_GetStudentInfo TO DYNGRP;

GO