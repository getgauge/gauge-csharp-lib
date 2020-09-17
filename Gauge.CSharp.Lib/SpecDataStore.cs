using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class SpecDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        public static object Get(string key)
        {
            lock (store)
            {
                object outVal;
                var valueExists = store.Value.TryGetValue(key, out outVal);
                return valueExists ? outVal : null;
            }
        }

        public static T Get<T>(string key)
        {
            lock (store)
            {
                return (T)Get(key);
            }
        }

        public static void Add(string key, object value)
        {
            lock (store)
            {
                store.Value[key] = value;

            }
        }

        public static void Clear()
        {
            lock (store)
            {
                store.Value.Clear();
            }
        }
    }
}