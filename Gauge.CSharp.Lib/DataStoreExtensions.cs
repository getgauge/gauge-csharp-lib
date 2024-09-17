namespace Gauge.CSharp.Lib;

public static class DataStoreExtensions
{
    internal static object Get(this AsyncLocal<DataStore> store, string key)
    {
        lock (store)
        {
            return store.Value.Get(key);
        }
    }

    internal static T Get<T>(this AsyncLocal<DataStore> store, string key)
    {
        lock (store)
        {
            return store.Value.Get<T>(key);
        }
    }

    internal static void Add(this AsyncLocal<DataStore> store, string key, object value)
    {
        lock (store)
        {
            store.Value.Add(key, value);
        }
    }

    internal static void Clear(this AsyncLocal<DataStore> store)
    {
        lock (store)
        {
            if (store.Value != null)
            {
                store.Value.Clear();
            }
        }
    }
}