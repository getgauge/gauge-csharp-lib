/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/

using System.Collections.Concurrent;
using System.Reflection;

namespace Gauge.CSharp.Lib;

public class DefaultClassInstanceManager : IClassInstanceManager
{
    private static readonly ConcurrentDictionary<Type, object> ClassInstanceMap = new();

    public void Initialize(List<Assembly> assemblies)
    {
        //nothing to do
    }

    public object Get(Type declaringType)
    {
        if (ClassInstanceMap.ContainsKey(declaringType))
            return ClassInstanceMap[declaringType];
        var instance = Activator.CreateInstance(declaringType);
        ClassInstanceMap.TryAdd(declaringType, instance);
        return instance;
    }

    public async Task InvokeMethod(MethodInfo method, int stream, params object[] parameters)
    {
        SetDataStores(stream);
        var instance = Get(method.DeclaringType);
        var response = method.Invoke(instance, parameters);
        if (response is Task task)
        {
            await task;
        }
    }

    private static void SetDataStores(int stream)
    {
        var dataStore = DataStoreFactory.GetDataStoresByStream(stream);
        lock (SuiteDataStore.Store)
        {
            SuiteDataStore.Store.Value = DataStoreFactory.SuiteDataStore;
        }
        lock (SpecDataStore.Store)
        {
            SpecDataStore.Store.Value = dataStore.GetValueOrDefault(DataStoreType.Spec, null);
        }
        lock (ScenarioDataStore.Store)
        {
            ScenarioDataStore.Store.Value = dataStore.GetValueOrDefault(DataStoreType.Scenario, null);
        }
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
        ClassInstanceMap.Clear();
    }
}