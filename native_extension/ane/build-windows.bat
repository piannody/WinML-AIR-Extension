REM Get the path to the script and trim to get the directory.
@echo off
SET SZIP="C:\Program Files\7-Zip\7z.exe"
SET AIR_PATH="D:\dev\sdks\AIR\AIRSDK_32\bin\"
echo Setting path to current directory to:
SET pathtome=%~dp0
echo %pathtome%

SET projectName=MLANE

REM Setup the directory.
echo Making directories.

IF NOT EXIST %pathtome%platforms mkdir %pathtome%platforms
IF NOT EXIST %pathtome%platforms\win  %pathtome%platforms\win
IF NOT EXIST %pathtome%platforms\win\x86  %pathtome%platforms\win\x86
IF NOT EXIST %pathtome%platforms\win\x86\release mkdir %pathtome%platforms\win\x86\release
IF NOT EXIST %pathtome%platforms\win\x64  %pathtome%platforms\win\x64
IF NOT EXIST %pathtome%platforms\win\x64\release mkdir %pathtome%platforms\win\x64\release

REM Copy SWC into place.
echo Copying SWC into place.
echo %pathtome%..\bin\%projectName%.swc
copy %pathtome%..\bin\%projectName%.swc %pathtome%

REM contents of SW