/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/

using System;
using System.Diagnostics;
using System.IO;

namespace Gauge.CSharp.Lib
{
    public class DefaultScreenshotWriter : ICustomScreenshotWriter
    {
        public string TakeScreenShot()
        {
            var screenshotPath = Path.Combine(Environment.GetEnvironmentVariable("gauge_screenshots_dir"), String.Format("screenshot-{0}.png", Guid.NewGuid().ToString()));
            var screenshotProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "gauge_screenshot",
                    Arguments = screenshotPath
                }
            };
            screenshotProcess.Start();
            screenshotProcess.WaitForExit();
            return Path.GetFileName(screenshotPath);
        }
    }
}