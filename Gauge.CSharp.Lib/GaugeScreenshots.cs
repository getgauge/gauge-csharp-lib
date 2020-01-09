// Copyright 2015 ThoughtWorks, Inc.

// This file is part of Gauge-CSharp.

// Gauge-CSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Gauge-CSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Gauge-CSharp.  If not, see <http://www.gnu.org/licenses/>.

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