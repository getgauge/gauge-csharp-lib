using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class DataStoreHelper
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> Store { get; set; } 
        private static DataStoreHelper Instance = null;

        private DataStoreHelper()
        {
        }

        public static DataStoreHelper From(ThreadLocal<ConcurrentDictionary<object, object>> store)
        {
            Store = store;
            if (Instance == null)
            {
                Instance = new DataStoreHelper();
            }
            return Instance;
        }

        internal object Get(string key)
        {
            lock (Store)
            {
                object outVal;
                var valueExists = Store.Value.TryGetValue(key, out outVal);
                return valueExists ? outVal : null;
            }
        }

        internal T Get<T>(string key)
        {
            lock (Store)
            {
                return (T)Get(key);
            }
        }

        internal void Add(string key, object value)
        {
            lock (Store)
            {
                Store.Value[key] = value;

            }
        }

        internal void Clear()
        {
            lock (Store)
            {
                Store.Value.Clear();
            }
        }
    }
}