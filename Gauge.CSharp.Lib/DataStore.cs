/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Concurrent;

namespace Gauge.CSharp.Lib;

/// <summary>
///     A key-value store that holds any object data.
/// </summary>
public class DataStore
{
    private ConcurrentDictionary<object, object> Dictionary { get; init; }

    public DataStore()
    {
        Dictionary = new ConcurrentDictionary<object, object>();
    }

    /// <summary>
    ///     Gets the number of entries in the datastore.
    /// </summary>
    public int Count => Dictionary.Count;

    /// <summary>
    ///     Gets the value that is stored against a given key.
    /// </summary>
    /// <param name="key">key for lookup</param>
    /// <returns>value as object, if exists, null when key does not exist.</returns>
    public object Get(string key)
    {
        var valueExists = Dictionary.TryGetValue(key, out object outVal);
        return valueExists ? outVal : null;
    }

    /// <summary>
    ///     Returns the value of the object cast as Type provided. Raises an exception when the key is not present.
    /// </summary>
    /// <typeparam name="T">The type to cast the return value</typeparam>
    /// <param name="key">key for lookup</param>
    /// <returns>value as T, if exists, null when key does not exist.</returns>
    public T Get<T>(string key)
    {
        var outVal = Get(key);
        return (outVal is T result) ? result : default;
    }

    /// <summary>
    ///     Adds a value to the datastore against given key.
    /// </summary>
    /// <param name="key">Key to store the value against</param>
    /// <param name="value">Value to store</param>
    public void Add(string key, object value)
    {
        Dictionary[key] = value;
    }

    /// <summary>
    ///     Clears the datastore
    /// </summary>
    public void Clear()
    {
        Dictionary.Clear();
    }
}