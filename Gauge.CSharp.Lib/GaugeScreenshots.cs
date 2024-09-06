/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
namespace Gauge.CSharp.Lib;

public static class GaugeScreenshots
{
    private static ICustomScreenshotWriter screenshotWriter = new DefaultScreenshotWriter();

    internal static List<string> ScreenshotFiles = new List<string>();

    public static void RegisterCustomScreenshotWriter(ICustomScreenshotWriter customScreenshotWriter)
    {
        screenshotWriter = customScreenshotWriter;
    }

    public static void Capture()
    {
        ScreenshotFiles.Add(screenshotWriter.TakeScreenShot());
    }
}