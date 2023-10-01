@echo off

echo Creating dummy plugin/PLGX files...

set PROJECT_PATH=%~dp0..\
set KEEPASS_PATH="%PROJECT_PATH%libs\KeePass.exe"
set SOURCE_PATH="%PROJECT_PATH%\Resources\KeePassDummyPlugin"

call :ResolvePath KEEPASS_PATH %KEEPASS_PATH%
call :ResolvePath SOURCE_PATH %SOURCE_PATH%

cd /d "%PROJECT_PATH%"

if exist plgx (
	rmdir /S /Q plgx
) 

if not exist plgx (
  mkdir plgx
)

echo Cleaning project directory...
if exist .\Resources\KeePassDummyPlugin\bin\ (
  rmdir /S /Q .\Resources\KeePassDummyPlugin\bin\
)

if exist .\Resources\KeePassDummyPlugin\obj\ (
  rmdir /S /Q .\Resources\KeePassDummyPlugin\obj\
)

echo Creating KeePass PLGX file...
%KEEPASS_PATH% --plgx-prereq-kp:2.54 --plgx-prereq-net:4.5 --plgx-create %SOURCE_PATH%

echo Moving PLGX file to the plgx directory...
move /Y .\Resources\KeePassDummyPlugin.plgx .\plgx\PlgxUnpackerNet.KeePassDummyPlugin.plgx

echo Creating KeePass PLGX file with pre/post build commands...
%KEEPASS_PATH% --plgx-prereq-kp:2.54 --plgx-prereq-net:4.5 --plgx-create %SOURCE_PATH% --plgx-build-pre:""""{PLGX_TEMP_DIR}Resources\Scripts\PreBuildScript.bat"""" --plgx-build-post:""""{PLGX_TEMP_DIR}Resources\Scripts\PostBuildScript.bat""""

echo Moving PLGX file to the plgx directory...
move /Y .\Resources\KeePassDummyPlugin.plgx .\plgx\PlgxUnpackerNet.KeePassDummyPlugin.WithCommands.plgx

echo Done.
rem pause
exit /b

:ResolvePath
  set %1=%~dpfn2
  exit /b
