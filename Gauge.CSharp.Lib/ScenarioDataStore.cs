using System.Collections.Concurrent;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class ScenarioDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        public static object Get(string key)
        {
            return store.Get(key);
        }

        public static T Get<T>(string key)
        {
            return store.Get<T>(key);
        }

        public static void Add(string key, object value)
        {
            store.Add(key, value);
        }

        public static void Clear()
        {
            store.Clear();
        }
    }
}