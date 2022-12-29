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

IF NOT E