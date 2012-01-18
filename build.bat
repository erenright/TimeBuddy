@echo off

set MSBUILD="C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\msbuild"
set COMPIL="C:\Program Files\Inno Setup 5\compil32"

echo === TimeBuddy Build ===
pause

del /q /f /s Output
rmdir Output
%msbuild% /t:Clean
if not errorlevel 0 goto CleanFailed

%msbuild% /p:Configuration=Release
if not errorlevel 0 goto BuildFailed

%compil% /cc TimeBuddy.iss
if not errorlevel 0 goto PackageFailed

echo *** Build successful ***

goto End


:CleanFailed
echo *** Failed to clean workspace ***
goto End

:BuildFailed
echo *** Failed to build ***
goto End

:PackageFailed
echo *** Failed to package ***
goto End

:End
