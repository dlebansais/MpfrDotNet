@echo off

setlocal

set PROJECTNAME=MpfrDotNet
set TESTPROJECTNAME=%PROJECTNAME%.Test
set RESULTFILENAME=Coverage-%PROJECTNAME%.xml
set RESULTFILEPATH=".\TestResults\%RESULTFILENAME%"
set CODECOV_VERSION=1.12.2
set CODECOV=Codecov.%CODECOV_VERSION%

nuget install CodeCov -Version %CODECOV_VERSION% -OutputDirectory packages

if not exist ".\packages\%CODECOV%\tools\codecov.exe" goto error_console1

call ..\Certification\set_tokens.bat

if exist %RESULTFILEPATH% del %RESULTFILEPATH%

dotnet test --project ./Test/%TESTPROJECTNAME% -c Debug -p:Platform=x64 -p:SolutionDir=%~dp0 --coverage --coverage-output-format cobertura --coverage-output %RESULTFILENAME% --results-directory .\TestResults

if exist %RESULTFILEPATH% .\packages\%CODECOV%\tools\codecov -f %RESULTFILEPATH% -t %MPFRDOTNET_CODECOV_TOKEN%
goto end

:error_console1
echo ERROR: Codecov not found.
goto end

:end
