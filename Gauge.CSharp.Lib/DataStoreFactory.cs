/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Concurrent;

namespace Gauge.CSharp.Lib;

/// <summary>
///     <remarks>
///         FOR GAUGE INTERNAL USE ONLY.
///     </remarks>
/// </summary>
public static class DataStoreFactory
{
    private static DataStore _suiteDataStore = null;
    private static readonly object _suiteDataStoreLock = new();
    private static readonly ConcurrentDictionary<int, ConcurrentDictionary<DataStoreType, DataStore>> _dataStores = new();

    internal static DataStore SuiteDataStore
    {
        get
        {
            lock (_suiteDataStoreLock)
            {
                return _suiteDataStore;
            }
        }
        private set
        {
            lock (_suiteDataStoreLock)
            {
                _suiteDataStore ??= value;
            }
        }
    }

    /// <summary>
    ///     <remarks>
    ///         FOR GAUGE INTERNAL USE ONLY.
    ///     </remarks>
    ///     Gets a datastore by stream number.
    /// </summary>
    internal static IReadOnlyDictionary<DataStoreType, DataStore> GetDataStoresByStream(int streamId)
    {
        return _dataStores.GetValueOrDefault(streamId, new());
    }

    /// <summary>
    ///     <remarks>
    ///         FOR GAUGE INTERNAL USE ONLY.
    ///     </remarks>
    ///     Adds a datastore by stream number.
    /// </summary>
    internal static void AddDataStore(int stream, DataStoreType storeType)
    {
        var dataStore = new DataStore();
        switch (storeType)
        {
            case DataStoreType.Suite: SetSuiteDataStore(stream, dataStore); break;
            case DataStoreType.Spec:
            case DataStoreType: SetStreamDataStore(stream, storeType, dataStore); break;
        }
    }

    private static void SetSuiteDataStore(int stream, DataStore dataStore)
    {
        SuiteDataStore = dataStore;
    }

    private static void SetStreamDataStore(int stream, DataStoreType storeType, DataStore dataStore)
    {
        if (!_dataStores.TryGetValue(stream, out ConcurrentDictionary<DataStoreType, DataStore> value))
        {
            value = new ConcurrentDictionary<DataStoreType, DataStore>();
            _dataStores[stream] = value;
        }

        value[storeType] = dataStore;
    }
}