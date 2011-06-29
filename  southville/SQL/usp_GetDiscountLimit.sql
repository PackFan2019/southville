IF EXISTS(SELECT name 
FROM sysobjects
WHERE name=N'usp_GetDiscountLimit'
AND TYPE='P'
)
DROP PROCEDURE usp_GetDiscountLimit
GO

CREATE PROCEDURE usp_GetDiscountLimit

AS

BEGIN

DECLARE @DiscountLimit AS INT

SET @DiscountLimit = 
(SELECT TOP 1 SAS_Discount_Limit
FROM SAS40100
WHERE SETUPKEY=1)

SELECT ISNULL(@DiscountLimit, 0) AS [Discount Limit]

END

GO

GRANT EXECUTE ON usp_GetDiscountLimit TO DYNGRP

GO

