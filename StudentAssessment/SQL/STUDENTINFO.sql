IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME=N'STUDENTINFO'
AND TYPE='V')
DROP VIEW STUDENTINFO
GO

CREATE VIEW STUDENTINFO

AS

SELECT     A1.CURNCYID, A1.CUSTCLAS, A1.CUSTNAME, A1.CUSTNMBR, A1.HOLD, A1.INACTIVE, A1.PRCLEVEL, A2.STUDENT_EXT_1_Firstname AS [First name], 
                      A2.STUDENT_EXT_10_PlaceofBirth AS [Place of Birth], A2.STUDENT_EXT_11_EmailAddress AS [Email Address], 
                      A2.STUDENT_EXT_12_Birthday AS Birthday, A2.STUDENT_EXT_13_LastSchoolAttended AS [Last School Attended], 
                      A2.STUDENT_EXT_2_Middlename AS [Middle name], A2.STUDENT_EXT_3_Lastname AS [Last name], A2.STUDENT_EXT_4_Level AS [Level], 
                      A2.STUDENT_EXT_5_Section AS Section, A2.STUDENT_EXT_6_Nationality AS Nationality, 
                      A2.STUDENT_EXT_7_OfficiallyEnrolled AS [Officially Enrolled], A2.STUDENT_EXT_8_Gender AS Gender, 
                      A2.STUDENT_EXT_9_Religion AS Religion
FROM         dbo.RM00101 AS A1 LEFT OUTER JOIN
                          (SELECT     B1.PT_UD_Key AS STUDENT_EXT_Key, B1.STUDENT_EXT_1_Firstname, B2.STUDENT_EXT_2_Middlename, 
                                                   B3.STUDENT_EXT_3_Lastname, B4.STUDENT_EXT_4_Level, B5.STUDENT_EXT_5_Section, B6.STUDENT_EXT_6_Nationality, 
                                                   B7.STUDENT_EXT_7_OfficiallyEnrolled, B8.STUDENT_EXT_8_Gender, B9.STUDENT_EXT_9_Religion, 
                                                   B10.STUDENT_EXT_10_PlaceofBirth, B11.STUDENT_EXT_11_EmailAddress, B12.STUDENT_EXT_12_Birthday, 
                                                   B13.STUDENT_EXT_13_LastSchoolAttended
                            FROM          (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_1_Firstname
                                                    FROM          dbo.EXT00101
                                                    WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 1)) AS B1 LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_2_Middlename
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 2)) AS B2 ON 
                                                   B1.PT_UD_Key = B2.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_3_Lastname
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 3)) AS B3 ON 
                                                   B1.PT_UD_Key = B3.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_4_Level
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 4)) AS B4 ON 
                                                   B1.PT_UD_Key = B4.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_5_Section
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 5)) AS B5 ON 
                                                   B1.PT_UD_Key = B5.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_6_Nationality
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 6)) AS B6 ON 
                                                   B1.PT_UD_Key = B6.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_7_OfficiallyEnrolled
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 7)) AS B7 ON 
                                                   B1.PT_UD_Key = B7.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_8_Gender
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 8)) AS B8 ON 
                                                   B1.PT_UD_Key = B8.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_9_Religion
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 9)) AS B9 ON 
                                                   B1.PT_UD_Key = B9.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_10_PlaceofBirth
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 10)) AS B10 ON 
                                                   B1.PT_UD_Key = B10.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_11_EmailAddress
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 11)) AS B11 ON 
                                                   B1.PT_UD_Key = B11.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, DATE1 AS STUDENT_EXT_12_Birthday
                                                         FROM          dbo.EXT00102
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 12)) AS B12 ON 
                                                   B1.PT_UD_Key = B12.PT_UD_Key LEFT OUTER JOIN
                                                       (SELECT     PT_UD_Key, STRGA255 AS STUDENT_EXT_13_LastSchoolAttended
                                                         FROM          dbo.EXT00101
                                                         WHERE      (PT_Window_ID = 'STUDENT_EXT') AND (PT_UD_Number = 13)) AS B13 ON B1.PT_UD_Key = B13.PT_UD_Key) AS A2 ON 
                      A2.STUDENT_EXT_Key = A1.CUSTNMBR

WHERE
	A1.HOLD = 0 
	AND A1.INACTIVE = 0

GO

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON STUDENTINFO TO DYNGRP;

GO