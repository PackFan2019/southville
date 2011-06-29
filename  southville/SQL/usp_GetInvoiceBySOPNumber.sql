IF EXISTS (SELECT NAME FROM sysobjects
WHERE name=N'usp_GetInvoiceBySOPNumber'
AND TYPE='P')
DROP PROCEDURE usp_GetInvoiceBySOPNumber
GO

CREATE PROCEDURE usp_GetInvoiceBySOPNumber
(
	@SOPNUMBE AS VARCHAR(15)
)

AS

SELECT 
	dbo.Trim(SOPTYPE) AS [SOP Type],
	dbo.Trim(SOPNUMBE) AS [SOP Number],
	dbo.Trim(DOCID) AS [Document ID],
	DOCDATE AS [Document Date],
	DUEDATE AS [Due Date],
	dbo.Trim(PYMTRMID) AS [Payment Terms ID],
	dbo.Trim(PRCLEVEL) AS [Price Level],
	dbo.Trim(LOCNCODE) AS [Default Site ID],
	dbo.Trim(BCHSOURC) AS [Batch Source],
	dbo.Trim(BACHNUMB) AS [Batch Number],
	dbo.Trim(CUSTNMBR) AS [Customer Number],
	dbo.Trim(CUSTNAME) AS [Customer Name],
	PYMTRCVD AS [Payment Received],
	ORPMTRVD AS [Originating Payment Received],
	ACCTAMNT AS [Account Amount],
	ORACTAMT AS [Originating Account Amount],
	dbo.Trim(CURNCYID) AS [Currency ID],
	dbo.Trim(USER2ENT) AS [User]
FROM SOP10100
WHERE SOPNUMBE = @SOPNUMBE

RETURN	
--exec usp_GetInvoiceBySOPNumber @SOPNUMBE = 'STDINV2855'
--exec usp_GetInvoiceBySOPNumber @SOPNUMBE = 'stdinv8000'


GO

GRANT EXECUTE ON usp_GetInvoiceBySOPNumber TO DYNGRP;

GO