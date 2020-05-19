/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gauge.CSharp.Lib
{
    public interface IClassInstanceManager
    {
        void Initialize(List<Assembly> assemblies);


        object Get(Type declaringType);


        void StartScope(string tag);


        void CloseScope();


        void ClearCache();
    }
}