/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class DefaultClassInstanceManager : IClassInstanceManager
    {
        private readonly ThreadLocal<ConcurrentDictionary<Type, object>> ClassInstanceMap = new ThreadLocal<ConcurrentDictionary<Type, object>>(() => new ConcurrentDictionary<Type, object>());

        public void Initialize(List<Assembly> assemblies)
        {
            //nothing to do
        }

        public object Get(Type declaringType)
        {
            if (ClassInstanceMap.Value.ContainsKey(declaringType))
                return ClassInstanceMap.Value[declaringType];
            var instance = Activator.CreateInstance(declaringType);
            ClassInstanceMap.Value.TryAdd(declaringType, instance);
            return instance;
        }

        public void StartScope(string tag)
        {
            //no scope
        }

        public void CloseScope()
        {
            //no scope
        }

        public void ClearCache()
        {
            ClassInstanceMap.Value.Clear();
        }
    }
}