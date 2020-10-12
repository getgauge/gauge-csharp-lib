using System.Collections.Concurrent;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class SpecDataStore
    {
        private static readonly ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        public static object Get(string key)
        {
            return DataStoreHelper.From(store).Get(key);
        }

        public static T Get<T>(string key)
        {
            return DataStoreHelper.From(store).Get<T>(key);
        }

        public static void Add(string key, object value)
        {
            DataStoreHelper.From(store).Add(key, value);
        }

        public static void Clear()
        {
            DataStoreHelper.From(store).Clear();
        }
    }
}