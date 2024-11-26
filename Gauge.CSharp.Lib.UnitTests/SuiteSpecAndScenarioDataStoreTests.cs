/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Reflection;

namespace Gauge.CSharp.Lib.UnitTests;

[TestFixture]
public class SuiteSpecAndScenarioDataStoreTests
{
    [SetUp]
    public void SetUp()
    {
        InitializeDataStore(typeof(SuiteDataStore));
        InitializeDataStore(typeof(SpecDataStore));
        InitializeDataStore(typeof(ScenarioDataStore));
    }

    private static void InitializeDataStore(Type type)
    {
        var scenarioDataStoreType = type;
        var storeProperty = scenarioDataStoreType.GetProperty("Store", BindingFlags.NonPublic | BindingFlags.Static);
        var store = storeProperty.GetValue(null) as AsyncLocal<DataStore>;
        store.Value = new DataStore();
    }

    [Test]
    public void ScenarioDataStoreTestAdd()
    {
        ScenarioDataStore.Add("myKey1", "myValue");
        Assert.That(ScenarioDataStore.Get("myKey1"), Is.EqualTo("myValue"));
    }

    [Test]
    public void ScenarioDataStoreTestAddObject()
    {
        var obj = new List<string>() { "val1" };
        ScenarioDataStore.Add("myKey2", obj);
        Assert.That(ScenarioDataStore.Get("myKey2"), Is.EqualTo(obj));
        Assert.That(ScenarioDataStore.Get("myKey2"), Is.InstanceOf<List<string>>());
    }

    [Test]
    public void ScenarioDataStoreTestAddTypedObject()
    {
        var obj = new List<string>() { "val1" };
        ScenarioDataStore.Add("myKey3", obj);
        Assert.That(ScenarioDataStore.Get<List<string>>("myKey3"), Is.SameAs(obj));
    }

    [Test]
    public void SpecDataStoreTestAdd()
    {
        SpecDataStore.Add("myKey3", "myValue");
        Assert.That(SpecDataStore.Get("myKey3"), Is.EqualTo("myValue"));
    }

    [Test]
    public void SpecDataStoreTestAddObject()
    {
        var obj = new List<string>() { "val1" };
        SpecDataStore.Add("myKey4", obj);
        Assert.That(SpecDataStore.Get("myKey4"), Is.EqualTo(obj));
        Assert.That(SpecDataStore.Get("myKey4"), Is.InstanceOf<List<string>>());
    }

    [Test]
    public void SpecDataStoreTestAddTypedObject()
    {
        var obj = new List<string>() { "val1" };
        SpecDataStore.Add("myKey3", obj);
        Assert.That(SpecDataStore.Get<List<string>>("myKey3"), Is.SameAs(obj));
    }

    [Test]
    public void SuiteDataStoreTestAdd()
    {
        SuiteDataStore.Add("myKey5", "myValue");
        Assert.That(SuiteDataStore.Get("myKey5"), Is.EqualTo("myValue"));
    }

    [Test]
    public void SuiteDataStoreTestAddObject()
    {
        var obj = new List<string>() { "val1" };
        SuiteDataStore.Add("myKey6", obj);
        Assert.That(SuiteDataStore.Get("myKey6"), Is.EqualTo(obj));
        Assert.That(SuiteDataStore.Get("myKey6"), Is.InstanceOf<List<string>>());
    }

    [Test]
    public void SuiteDataStoreTestAddTypedObject()
    {
        var obj = new List<string>() { "val1" };
        SuiteDataStore.Add("myKey3", obj);
        Assert.That(SuiteDataStore.Get<List<string>>("myKey3"), Is.SameAs(obj));
    }

    [Test]
    public void AllDataStoreTestAdd()
    {
        ScenarioDataStore.Add("myKey7", "scenario");
        SpecDataStore.Add("myKey7", "spec");
        SuiteDataStore.Add("myKey7", "suite");
        Assert.Multiple(() =>
        {
            Assert.That(ScenarioDataStore.Get("myKey7"), Is.EqualTo("scenario"));
            Assert.That(SpecDataStore.Get("myKey7"), Is.EqualTo("spec"));
            Assert.That(SuiteDataStore.Get("myKey7"), Is.EqualTo("suite"));
        });
    }

    [Test]
    public void AllDataStoreTestClean()
    {
        ScenarioDataStore.Add("myKey7", "scenario");
        SpecDataStore.Add("myKey7", "spec");
        SuiteDataStore.Add("myKey7", "suite");
        Assert.Multiple(() =>
        {
            Assert.That(ScenarioDataStore.Get("myKey7"), Is.EqualTo("scenario"));
            Assert.That(SpecDataStore.Get("myKey7"), Is.EqualTo("spec"));
            Assert.That(SuiteDataStore.Get("myKey7"), Is.EqualTo("suite"));
        });
        ScenarioDataStore.Clear();
        SpecDataStore.Clear();
        SuiteDataStore.Clear();
        Assert.Multiple(() =>
        {
            Assert.That(ScenarioDataStore.Get("myKey7"), Is.Null);
            Assert.That(SpecDataStore.Get("myKey7"), Is.Null);
            Assert.That(SuiteDataStore.Get("myKey7"), Is.Null);
        });
    }

    [Test]
    public void AllDataStoreTestAddObject()
    {
        var obj1 = new List<string>() { "scenario" };
        var obj2 = new List<string>() { "spec" };
        var obj3 = new List<string>() { "suite" };
        ScenarioDataStore.Add("myKey8", obj1);
        Assert.That(ScenarioDataStore.Get("myKey8"), Is.EqualTo(obj1));
        Assert.That(ScenarioDataStore.Get("myKey8"), Is.InstanceOf<List<string>>());
        SpecDataStore.Add("myKey8", obj2);
        Assert.That(SpecDataStore.Get("myKey8"), Is.EqualTo(obj2));
        Assert.That(SpecDataStore.Get("myKey8"), Is.InstanceOf<List<string>>());
        SuiteDataStore.Add("myKey8", obj3);
        Assert.That(SuiteDataStore.Get("myKey8"), Is.EqualTo(obj3));
        Assert.That(SuiteDataStore.Get("myKey8"), Is.InstanceOf<List<string>>());
    }

    [Test]
    public void ScenarioDataStoreParallelInvoke()
    {
        Task.WaitAll(new Task[6]
        {
            Task.Run(() => ScenarioDataStore.Add("sckey1", "Scenario1"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey1"), Is.EqualTo("Scenario1"))),
            Task.Run(() => ScenarioDataStore.Add("sckey2", "Scenario2"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey2"), Is.EqualTo("Scenario2"))),
            Task.Run(() => ScenarioDataStore.Add("sckey3", "Scenario3"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey3"), Is.EqualTo("Scenario3"))),
            Task.Run(() => ScenarioDataStore.Add("sckey4", "Scenario4"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey4"), Is.EqualTo("Scenario4"))),
            Task.Run(() => ScenarioDataStore.Add("sckey5", "Scenario5"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey5"), Is.EqualTo("Scenario5"))),
            Task.Run(() => ScenarioDataStore.Add("sckey6", "Scenario6"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey6"), Is.EqualTo("Scenario6")))
        });
    }

    [Test]
    public void AllDataStoreParallelInvoke()
    {
        Task.WaitAll(new Task[12]
        {
            Task.Run(() => ScenarioDataStore.Add("sckey7", "Scenario7"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey7"), Is.EqualTo("Scenario7"))),

            Task.Run(() => ScenarioDataStore.Add("sckey8", "Scenario8"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey8"), Is.EqualTo("Scenario8"))),

            Task.Run(() => ScenarioDataStore.Add("sckey9", "Scenario9"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey9"), Is.EqualTo("Scenario9"))),

            Task.Run(() => ScenarioDataStore.Add("sckey10", "Scenario10"))
            .ContinueWith((o) => Assert.That(ScenarioDataStore.Get("sckey10"), Is.EqualTo("Scenario10"))),

            Task.Run(() => SpecDataStore.Add("spec1", "Spec1"))
            .ContinueWith((o) => Assert.That(SpecDataStore.Get("spec1"), Is.EqualTo("Spec1"))),

            Task.Run(() => SpecDataStore.Add("spec2", "Spec2"))
            .ContinueWith((o) => Assert.That(SpecDataStore.Get("spec2"), Is.EqualTo("Spec2"))),

            Task.Run(() => SpecDataStore.Add("spec3", "Spec3"))
            .ContinueWith((o) => Assert.That(SpecDataStore.Get("spec3"), Is.EqualTo("Spec3"))),

            Task.Run(() => SpecDataStore.Add("spec4", "Spec4"))
            .ContinueWith((o) => Assert.That(SpecDataStore.Get("spec4"), Is.EqualTo("Spec4"))),

            Task.Run(() => SuiteDataStore.Add("suite1", "Suite1"))
            .ContinueWith((o) => Assert.That(SuiteDataStore.Get("suite1"), Is.EqualTo("Suite1"))),

            Task.Run(() => SuiteDataStore.Add("suite2", "Suite2"))
            .ContinueWith((o) => Assert.That(SuiteDataStore.Get("suite2"), Is.EqualTo("Suite2"))),

            Task.Run(() => SuiteDataStore.Add("suite3", "Suite3"))
            .ContinueWith((o) => Assert.That(SuiteDataStore.Get("suite3"), Is.EqualTo("Suite3"))),

            Task.Run(() => SuiteDataStore.Add("suite4", "Suite4"))
            .ContinueWith((o) => Assert.That(SuiteDataStore.Get("suite4"), Is.EqualTo("Suite4")))
        });
    }
}