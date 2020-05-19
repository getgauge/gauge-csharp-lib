/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    public class GaugeMessages
    {
        internal static List<string> Messages = new List<string>();

        public static void WriteMessage(string message)
        {
            Messages.Add(message);
        }

        public static void WriteMessage(string message, params object[] args)
        {
            Messages.Add(string.Format(message, args));
        }
    }
}