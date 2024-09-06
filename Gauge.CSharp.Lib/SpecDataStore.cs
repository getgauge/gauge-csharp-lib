using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class SpecDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        private static ConcurrentDictionary<object, object> asyncStore = new ConcurrentDictionary<object, object>();

        public static object Get(string key)
        {
            return useAsyncFriendlyDatastore() ? asyncStore.Get(key) : store.Get(key);
        }

        public static T Get<T>(string key)
        {
            return useAsyncFriendlyDatastore() ? asyncStore.Get<T>(key) : store.Get<T>(key);
        }

        public static void Add(string key, object value)
        {
            if(useAsyncFriendlyDatastore())
            {
                asyncStore.Add(key, value);
                return;
            }
            store.Add(key, value);
        }

        public static void Clear()
        {
            if(useAsyncFriendlyDatastore())
            {
                asyncStore.Clear();
                return;
            }
            store.Clear();
        }

        private static Boolean useAsyncFriendlyDatastore()
        {
            string useAsyncFriendlyDatastore = Environment.GetEnvironmentVariable("use_async_friendly_datastores");
            if(String.IsNullOrEmpty(useAsyncFriendlyDatastore))
                return false;
            return useAsyncFriendlyDatastore.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
    }
}