IF EXISTS(SELECT name 
FROM sysobjects
WHERE name=N'usp_CheckMarkdownPassword'
AND TYPE='P'
)
DROP PROCEDURE usp_CheckMarkdownPassword
GO

CREATE PROCEDURE usp_CheckMarkdownPassword
(
@Password CHAR(15)
)

AS

BEGIN

DECLARE @StoredPassword AS CHAR(15)
DECLARE @Result AS INT

SET @Result = 0
SET @StoredPassword = (SELECT TOP 1 SAS_Markdown_Password
FROM SAS40100
WHERE SETUPKEY=1)

IF dbo.uf_Trim(@StoredPassword)<>@Password
BEGIN
	SET @Result = 1
END

SELECT @Result AS [Result]

END

GO

GRANT EXECUTE ON usp_CheckMarkdownPassword TO DYNGRP

GO