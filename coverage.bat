@echo off

setlocal

set PROJECTNAME=MpfrDotNet
set TESTPROJECTNAME=%PROJECTNAME%.Test
rem One coverage report per target framework of the test project.
set RESULTFILENAME1=Coverage-%PROJECTNAME%-net481.xml
set RESULTFILEPATH1=".\TestResults\%RESULTFILENAME1%"
set RESULTFILENAME2=Coverage-%PROJECTNAME%-net10.0.xml
set RESULTFILEPATH2=".\TestResults\%RESULTFILENAME2%"
set CODECOV_VERSION=1.12.2
set CODECOV=Codecov.%CODECOV_VERSION%

nuget install CodeCov -Version %CODECOV_VERSION% -OutputDirectory packages
dotnet tool install -g dotnet-stryker --version 4.16.0

if not exist ".\packages\%CODECOV%\tools\codecov.exe" goto error_console1

call ..\Certification\set_tokens.bat

if exist %RESULTFILEPATH1% del %RESULTFILEPATH1%
if exist %RESULTFILEPATH2% del %RESULTFILEPATH2%

dotnet test --project ./Test/%TESTPROJECTNAME% -c Debug -p:Platform=x64 -p:SolutionDir=%~dp0 -f net481 --coverage --coverage-output-format cobertura --coverage-output %RESULTFILENAME1% --results-directory .\TestResults
dotnet test --project ./Test/%TESTPROJECTNAME% -c Debug -p:Platform=x64 -p:SolutionDir=%~dp0 -f net10.0 --coverage --coverage-output-format cobertura --coverage-output %RESULTFILENAME2% --results-directory .\TestResults

if not exist %RESULTFILEPATH1% goto error_console2
if not exist %RESULTFILEPATH2% goto error_console2

rem Codecov merges the two reports into one for the commit.
.\packages\%CODECOV%\tools\codecov -f %RESULTFILEPATH1% %RESULTFILEPATH2% -t %MPFRDOTNET_CODECOV_TOKEN%

rem Mutation testing, on the net10.0 tests only. Stryker builds the projects itself, and MSBuild reads the Platform
rem environment variable as a property: without it, the native DLLs are not copied next to the tests.
rem Release, because some mutants remove a check and make MPIR or MPFR abort, and with the Debug C runtime each abort
rem opens a dialog that waits for a click.
set Platform=x64
pushd .\Test\%TESTPROJECTNAME%
dotnet stryker -p %PROJECTNAME%.csproj --configuration Release --target-framework net10.0 --output . --reporter markdown --reporter html
if exist .gitignore del .gitignore
popd
goto end

:error_console1
echo ERROR: Codecov not found.
goto end

:error_console2
echo ERROR: A coverage report is missing, so nothing was uploaded.
goto end

:end
