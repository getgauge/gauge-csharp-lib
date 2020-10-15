using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class SpecDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        public static object Get(string key)
        {
            return CommonDataStore.WithDataStore(store).Get(key);
        }

        public static T Get<T>(string key)
        {
            return CommonDataStore.WithDataStore(store).Get<T>(key);
        }

        public static void Add(string key, object value)
        {
            CommonDataStore.WithDataStore(store).Add(key, value);
        }

        public static void Clear()
        {
            CommonDataStore.WithDataStore(store).Clear();
        }
    }
}