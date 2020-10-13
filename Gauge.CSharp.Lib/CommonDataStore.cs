using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class CommonDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store;
        private static CommonDataStore instance = null;
        public static CommonDataStore WithDataStore(ThreadLocal<ConcurrentDictionary<object, object>> Store)
        {
            store = Store;
            if(instance == null)
            {
                instance = new CommonDataStore();
            }
            return instance;
        }

        internal object Get(string key)
        {
            lock (store)
            {
                object outVal;
                var valueExists = store.Value.TryGetValue(key, out outVal);
                return valueExists ? outVal : null;
            }
        }

        internal T Get<T>(string key)
        {
            lock (store)
            {
                return (T)Get(key);
            }
        }

        internal void Add(string key, object value)
        {
            lock (store)
            {
                store.Value[key] = value;

            }
        }

        internal void Clear()
        {
            lock (store)
            {
                store.Value.Clear();
            }
        }
    }
}