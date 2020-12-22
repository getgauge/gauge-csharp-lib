# Gauge CSharp Lib
[![Build Status](https://travis-ci.org/getgauge/gauge-csharp-lib.svg?branch=master)](https://travis-ci.org/getgauge/gauge-csharp-lib)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v1.4%20adopted-ff69b4.svg)](CODE_OF_CONDUCT.md)

`Gauge.CSharp.Lib` is a dll that brings in Gauge's data types to C#. It is hosted in [Nuget](https://www.nuget.org/packages/Gauge.CSharp.Lib/).

You will need [Gauge](https://docs.gauge.org/getting_started/installing-gauge.html)
and [Gauge-dotnet plugin](https://github.com/getgauge/gauge-dotnet) installed before installing `Lib`.

## Build

From the root of this repository, run (`build.sh` on Unix (with `dotnet core`) `build.cmd` on Windows)
 * `./build.sh build`
 * `./build.sh test`, runs nunit tests
 * `.build.sh package`, creates the `nuget` package;

## License

This program is licensed under:

[Apache License, Version 2.0](https://www.apache.org/licenses/LICENSE-2.0.txt)

## Sponsors

This project is sponsored by [Thoughtworks Inc.](http://www.thoughtworks.com/).
