/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Gauge.CSharp.Lib.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Step : System.Attribute
    {
        private readonly string[] _stepText;

        public Step(string stepText)
        {
            _stepText = new[] {stepText};
        }

        public Step(params string[] stepText)
        {
            _stepText = stepText;
        }

        public IEnumerable<string> Names => _stepText;
    }
}