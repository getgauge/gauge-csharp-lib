using System.Collections.Concurrent;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public static class DataStoreExtensions
    {
        internal static object Get(this ThreadLocal<ConcurrentDictionary<object, object>> store, string key)
        {
            lock (store)
            {
                object outVal;
                var valueExists = store.Value.TryGetValue(key, out outVal);
                return valueExists ? outVal : null;
            }
        }

        internal static T Get<T>(this ThreadLocal<ConcurrentDictionary<object, object>> store, string key)
        {
            lock (store)
            {
                return (T)store.Get(key);
            }
        }

        internal static void Add(this ThreadLocal<ConcurrentDictionary<object, object>> store, string key, object value)
        {
            lock (store)
            {
                store.Value[key] = value;

            }
        }

        internal static void Clear(this ThreadLocal<ConcurrentDictionary<object, object>> store)
        {
            lock (store)
            {
                store.Value.Clear();
            }
        }
    }
}