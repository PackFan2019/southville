@ECHO OFF

:BEGIN
CLS
	SET /P D=Please supply ServerName:		
	SET /P A=Please supply Username  :		
	SET /P B=Please supply Password  :		
	SET /P C=Please supply Database  :		
ECHO. 
ECHO.
ECHO	ADVISORY:
ECHO		* It is advised to BACKUP FIRST the company database!
ECHO		* It is advised not to use your Server until this is done.
ECHO.
	SET /P E=Are you sure you want to continue? (Y/N):  

	IF "%E%"=="Y" GOTO GSCINSTALL1
	IF "%E%"=="y" GOTO GSCINSTALL1
	IF "%E%"=="n" GOTO CONTINUE2
	IF "%E%"=="N" GOTO CONTINUE2

:GSCINSTALL1

ECHO.
ECHO.
ECHO	Installing function(s)....
ECHO.
for /f %%z IN ('dir /b uf_*.sql') DO osql /U %A% /P %B% /d %C% /S %D% -i %%z
ECHO.
ECHO.
ECHO	Installing tables(s)....
ECHO.
for /f %%z IN ('dir /b SISC*.sql') DO osql /U %A% /P %B% /d %C% /S %D% -i %%z
ECHO.
ECHO.
ECHO	Installing stored procedure(s)....
ECHO.
for /f %%z IN ('dir /b usp_*.sql') DO osql /U %A% /P %B% /d %C% /S %D% -i %%z
ECHO.
ECHO.
ECHO	Installing view(s)...
ECHO.
for /f %%z IN ('dir /b uv_*.sql') DO osql /U %A% /P %B% /d %C% /S %D% -i %%z
osql /U %A% /P %B% /d %C% /S %D% -i STUDENTINFO.sql
ECHO.
ECHO.
ECHO	Scripts successfully installed!

PAUSE

:END
