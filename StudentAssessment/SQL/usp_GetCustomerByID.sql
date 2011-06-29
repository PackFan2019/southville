IF EXISTS (SELECT NAME FROM sysobjects
WHERE NAME=N'usp_GetCustomerByID'
AND TYPE='P')
DROP PROCEDURE usp_GetCustomerByID
GO

CREATE PROCEDURE usp_GetCustomerByID
(
	@Customer_ID AS CHAR(15)
)

AS
/*do not change aliases*/
SELECT
	dbo.uf_Trim(Customer_Master.CUSTNMBR) AS [Customer Number],
	dbo.uf_Trim(Customer_Master.CUSTNAME) AS [Customer Name],
	dbo.uf_Trim(Customer_Master.PRCLEVEL) AS [Price Level],
	dbo.uf_Trim(Customer_Master.CUSTCLAS) AS [Customer Class],
	dbo.uf_Trim(Customer_Master.CURNCYID) AS [Currency ID],
	dbo.uf_Trim(Student_Info.[Level]) AS [Grade Level],
	dbo.uf_Trim(Student_Info.[Officially Enrolled]) AS [Status],
	dbo.uf_Trim(Scheduled_Instalments_Master.PMNTSCHLDID) AS [Plan]
FROM RM00101 Customer_Master

LEFT JOIN RVLSP004 Scheduled_Instalments_Master
ON 
Customer_Master.CUSTNMBR = Scheduled_Instalments_Master.CUSTNMBR

LEFT JOIN STUDENTINFO Student_Info
ON 
Customer_Master.CUSTNMBR = Student_Info.CUSTNMBR

WHERE
	Customer_Master.INACTIVE = 0
	AND Customer_Master.HOLD = 0
	AND Customer_Master.CUSTNMBR = @Customer_ID

RETURN


GO

GRANT EXECUTE ON usp_GetCustomerByID TO DYNGRP;

GO