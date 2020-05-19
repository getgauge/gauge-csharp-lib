/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    public class MessageCollector
    {
        public static List<string> GetAllPendingMessages()
        {
            var pendingMessages = new List<string>(GaugeMessages.Messages);
            Clear();
            return pendingMessages;
        }

        public static void Clear()
        {
            GaugeMessages.Messages.Clear();
        }
    }
}