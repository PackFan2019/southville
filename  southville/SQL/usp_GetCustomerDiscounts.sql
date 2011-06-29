IF EXISTS(SELECT NAME FROM sysobjects
WHERE NAME = N'usp_GetCustomerDiscounts'
AND TYPE = 'P'
)
DROP PROCEDURE usp_GetCustomerDiscounts
GO

CREATE PROCEDURE usp_GetCustomerDiscounts
(
	@Customer_ID CHAR(15)
)

AS

SELECT 
	dbo.uf_Trim(Discounts_Customer_Rel.Master_ID) AS [Customer No],
	dbo.uf_Trim(Discounts_Customer_Rel.MSTRCDTY),
	dbo.uf_Trim(Discounts_Customer_Rel.SEQNUMBR),
	dbo.uf_Trim(Discounts_Master.SAS_Discount_ID) AS [Discount ID], 
	dbo.uf_Trim(Discounts_Master.SAS_Discount_Description) AS [Discount Description],
	Discounts_Master.SAS_Discount_Percent AS [Discount Percentage],
	Discounts_Master.SAS_Discount_Editable AS [Discount Type]

FROM [SAS00101] Discounts_Customer_Rel

INNER JOIN [SAS00100] Discounts_Master
ON Discounts_Customer_Rel.SAS_Discount_ID = Discounts_Master.SAS_Discount_ID

WHERE Discounts_Customer_Rel.MSTRCDTY=0
AND Discounts_Customer_Rel.Master_ID=@Customer_ID

ORDER BY Discounts_Master.SAS_Discount_Percent DESC
, Discounts_Customer_Rel.SEQNUMBR

--EXEC usp_GetCustomerDiscounts ''
--SELECT * FROM SAS00100

GO

GRANT EXECUTE ON usp_GetCustomerDiscounts TO DYNGRP;

GO