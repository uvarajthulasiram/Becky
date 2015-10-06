@ECHO OFF

SET Target=%1
SET Configuration=%2
SET ProductVersion=%3
SET MSBuildExe="%ProgramFiles(x86)%\MSBuild\12.0\Bin\msbuild.exe"

IF (%1)==() SET Target=Build
IF (%2)==() SET Configuration=Debug
IF (%3)==() SET ProductVersion=0.0.0.0
IF NOT EXIST %MSBuildExe% GOTO MSBuildNotFound

:: Build product
:: --------------------------------------------------
:Build

"%ProgramFiles(x86)%\MSBuild\12.0\Bin\msbuild.exe" .build\build.targets /verbosity:normal /target:%Target% /p:Configuration=%Configuration% /p:ProductVersion=%ProductVersion%
if errorlevel 1 pause

GOTO Exit

:MSBuildNotFound
ECHO MSBuild Not Found: %MSBuildExe%
PAUSE
GOTO Exit

:Exit
