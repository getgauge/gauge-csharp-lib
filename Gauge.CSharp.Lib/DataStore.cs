/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    /// <summary>
    ///     A key-value store that holds any object data.
    /// </summary>
    [Serializable]
    public class DataStore
    {
        public DataStore()
        {
            Initialize();
        }

        private Dictionary<object, object> Dictionary { get; set; }

        /// <summary>
        ///     Gets the number of entries in the datastore.
        /// </summary>
        public int Count => Dictionary.Count;

        /// <summary>
        ///     Initializes a datastore, with a new dictionary.
        /// </summary>
        public void Initialize()
        {
            Dictionary = new Dictionary<object, object>();
        }

        /// <summary>
        ///     Gets the value that is stored against a given key.
        /// </summary>
        /// <param name="key">key for lookup</param>
        /// <returns>value as object, if exists, null when key does not exist.</returns>
        public object Get(string key)
        {
            object outVal;
            var valueExists = Dictionary.TryGetValue(key, out outVal);
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
            return (T) Get(key);
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
}