/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    public class ScreenshotFilesCollector
    {
        public static List<string> GetAllPendingScreenshotFiles()
        {
            var screenshotFiles = new List<string>(GaugeScreenshots.ScreenshotFiles);
            Clear();
            return screenshotFiles;
        }

        public static void Clear()
        {
            GaugeScreenshots.ScreenshotFiles.Clear();
        }
    }
}