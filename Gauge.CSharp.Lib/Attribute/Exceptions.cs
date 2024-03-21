/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;

namespace Gauge.CSharp.Lib.Attribute
{
    [Serializable]
    public class SkipScenarioException : Exception
    {
        public SkipScenarioException() : base() { }

        public SkipScenarioException(string message) : base(message) { }

        public SkipScenarioException(string message, Exception innerException) : base(message, innerException) { }

        protected SkipScenarioException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}