/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Gauge.CSharp.Lib
{
    public class GaugeScreenshots
    {
        private static ICustomScreenshotWriter screenshotWriter = new DefaultScreenshotWriter();

        internal static List<string> ScreenshotFiles = new List<string>();
        private static ICustomScreenshotGrabber screenshotGrabber = null;

        public static void RegisterCustomScreenshotGrabber(ICustomScreenshotGrabber customScreenshotGrabber)
        {
            screenshotGrabber = customScreenshotGrabber;
        }


        public static void RegisterCustomScreenshotWriter(ICustomScreenshotWriter customScreenshotWriter)
        {
            screenshotWriter = customScreenshotWriter;
        }

        public static void Capture()
        {
            if (screenshotGrabber != null)
            {
                var screenshotPath = Path.Combine(Environment.GetEnvironmentVariable("gauge_screenshots_dir"), String.Format("screenshot-{0}.png", Guid.NewGuid().ToString()));
                var screenshotBytes = screenshotGrabber.TakeScreenShot();
                File.WriteAllBytes(screenshotPath, screenshotBytes);
                ScreenshotFiles.Add(Path.GetFileName(screenshotPath));
            } else {
                ScreenshotFiles.Add(screenshotWriter.TakeScreenShot());
            }
        }
    }
}