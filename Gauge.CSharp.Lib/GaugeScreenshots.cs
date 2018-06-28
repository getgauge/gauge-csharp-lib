﻿// Copyright 2015 ThoughtWorks, Inc.

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

using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    public class GaugeScreenshots
    {
        private static ICustomScreenshotGrabber screenGrabber = new DefaultScreenGrabber();

        internal static List<byte[]> Screenshots = new List<byte[]>();

        public static void RegisterCustomScreenshotGrabber(ICustomScreenshotGrabber customScreenshotGrabber)
        {
            screenGrabber = customScreenshotGrabber;
        }

        public static void Capture()
        {
            Screenshots.Add(screenGrabber.TakeScreenShot());
        }
    }
}