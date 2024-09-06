@echo off
set tasks=build test package
for %%a in (%tasks%) do (
    if %1==%%a goto %1
)

echo Options: "[build | test | package]"
goto :eof

:build
    dotnet build -c release
    goto :eof

:test
    dotnet test -c debug ./Gauge.CSharp.Lib.UnitTests/Gauge.CSharp.Lib.UnitTests.csproj
    goto :eof

:package
    rmdir /s /q artifacts
    dotnet pack -c release -o artifacts Gauge.CSharp.Lib
    goto :eof

