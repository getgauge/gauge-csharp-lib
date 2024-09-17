/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
namespace Gauge.CSharp.Lib;

/// <summary>
///     Defines a custom implementation to capture screenshot on failure.
/// </summary>
public interface ICustomScreenshotWriter
{
    /// <summary>
    ///     Define your own way to take screenshot, that is best applicable to your system-under-test.
    ///     Gauge can take this screenshot and use it for reporting.
    ///     By default, Gauge attempts to capture the active window screenshot, on failure.
    /// </summary>
    /// <returns>A screenshot file path, containing the screenshot path as string.</returns>
    string TakeScreenShot();
}