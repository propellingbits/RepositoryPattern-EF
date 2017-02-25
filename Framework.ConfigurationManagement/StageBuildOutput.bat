REM %1 - Build Target Name
REM %2 - Configuration Name
REM @echo off

SETLOCAL
REM Check that we have all the command line parameters
IF [%1]==[] (
	ECHO BuildTargetName was not specified
	GOTO :ShowUsage
) ELSE (
	SET BuildTargetName=%1
)
IF [%2]==[] (
	ECHO ConfigName was not specified
	GOTO :ShowUsage
) ELSE (
	SET ConfigName=%2
)

REM Extract the version number from the framework AssemblyVersion file
CHDIR
SET AssemblyVersionFile=..\..\..\Framework.ConfigurationManagement\AssemblyInfo\Framework.AssemblyVersion.cs
IF NOT EXIST %AssemblyVersionFile% (
	ECHO File %AssemblyVersionFile% is missing
	SET ERRORLEVEL=3
	GOTO :ProgramExit
)
FOR /F "tokens=2 delims=()" %%A IN ('FIND /I "AssemblyFileVersion" %AssemblyVersionFile%') DO SET AssemblyVersion=%%~A
IF NOT ERRORLEVEL 0 (
	ECHO Could NOT determine framework version from file %AssemblyVersionFile%
	SET ERRORLEVEL=4
	GOTO :ProgramExit
)
FOR /F "tokens=1,2 delims=." %%A IN ("%AssemblyVersion%") DO SET EcisFrameworkVersion=%%A.%%B

REM Construct the target folder path and confirm that it exists
SET TargetFolder=..\..\..\..\..\Bin\Framework\%EcisFrameworkVersion%\%ConfigName%\
IF NOT EXIST %TargetFolder% (
 	ECHO Folder %TargetFolder% is missing
	SET ERRORLEVEL=2
	GOTO :ProgramExit
)

REM Copy the files to the target folder
xcopy %BuildTargetName%.??? %TargetFolder% /Y /R /D /F
ATTRIB +R %TargetFolder%%BuildTargetName%.???
SET ERRORLEVEL=0
GOTO :ProgramExit

:ShowUsage
SET ERRORLEVEL=1
ECHO .
ECHO STAGEBUILDOUTPUT BuildTargetDir BuildTargetName FrameworkVersion ConfigName
ECHO   BuildTargetName - Target name of the build. Use visual studio macro $(TargetName)
ECHO   ConfigName - Configuration of the build. Use visual studio macro $(ConfigurationName)

:ProgramExit
REM ECHO Exiting with ERRORLEVEL %ERRORLEVEL%
ENDLOCAL