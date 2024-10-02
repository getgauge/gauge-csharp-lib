/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
namespace Gauge.CSharp.Lib;

[Serializable]
public class SkipScenarioException : Exception
{
    public SkipScenarioException() : base() { }

    public SkipScenarioException(string message) : base(message)
    {
        GaugeMessages.WriteMessage(message);
    }

    public SkipScenarioException(string message, Exception innerException) : base(message, innerException)
    {
        GaugeMessages.WriteMessage(message);
    }
}