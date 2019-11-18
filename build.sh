#!/bin/bash

function checkCommand() {
    command -v $1 >/dev/null 2>&1 || { echo >&2 "$1 is not installed, aborting."; exit 1; }
}

function build() {
    checkCommand "dotnet"
    dotnet build -c release
}

function test() {
    checkCommand "dotnet"
    dotnet test -c release ./Gauge.CSharp.Lib.UnitTests/Gauge.CSharp.Lib.UnitTests.csproj
}

function package() {
    checkCommand "dotnet"
    rm -rf deploy artifacts
    dotnet pack -c release -o ../artifacts Gauge.CSharp.Lib
}

tasks=(build test package)
if [[ " ${tasks[@]} " =~ " $1 " ]]; then
    $1
    exit 0
fi

echo Options: [build \| test \| package \| install \| uninstall \| forceinstall]
