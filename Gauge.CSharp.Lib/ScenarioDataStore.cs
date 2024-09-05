namespace Gauge.CSharp.Lib;

public class ScenarioDataStore
{
    internal static AsyncLocal<DataStore> Store { get; } = new AsyncLocal<DataStore>();

    public static object Get(string key)
    {
        return Store.Get(key);
    }

    public static T Get<T>(string key)
    {
        return Store.Get<T>(key);
    }

    public static void Add(string key, object value)
    {
        Store.Add(key, value);
    }

    public static void Clear()
    {
        Store.Clear();
    }
}