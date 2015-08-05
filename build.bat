@echo off

set MSBUILD=C:\Program Files (x86)\MSBuild\14.0\Bin
set BUILD=%CD%\.build

set PATH=%MSBUILD%;%PATH%

if not exist "%MSBUILD%\msbuild.exe" (
	echo MSBuild Not Found, Aborting
	goto end
)

echo ---------- Cleaning Solution
del Build\* /q /s
echo ---------- Building Solution
msbuild.exe CM3D2.CameraControlEx.Plugin\CM3D2.CameraControlEx.Plugin.csproj /p:Platform=x86,OutputPath=../Build
:end
pause