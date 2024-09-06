/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
namespace Gauge.CSharp.Lib.UnitTests;

[TestFixture]
public class DataStoreFactoryTests
{
    [SetUp]
    public void Setup()
    {
        DataStoreFactory.ClearAllDataStores();
    }

    [Test]
    public void AddDataStore_ShouldSetTheSuiteDataStore_WhenCalledForSuiteDataStoreType()
    {
        DataStoreFactory.AddDataStore(1, DataStoreType.Suite);
        Assert.IsNotNull(DataStoreFactory.SuiteDataStore);
    }

    [Test]
    public void AddDataStore_ShouldNotOverwriteTheSuiteDataStore_WhenCalledForSuiteDataStoreTypeMoreThanOnce()
    {
        DataStoreFactory.AddDataStore(1, DataStoreType.Suite);
        var dataStore = DataStoreFactory.SuiteDataStore;
        DataStoreFactory.AddDataStore(1, DataStoreType.Suite);
        Assert.AreSame(dataStore, DataStoreFactory.SuiteDataStore);
    }

    [Test]
    public void AddDataStore_ShouldSetTheSpecDataStore_WhenCalledForSpecDataStoreType()
    {
        DataStoreFactory.AddDataStore(1, DataStoreType.Spec);
        Assert.IsNotNull(DataStoreFactory.GetDataStoresByStream(1)[DataStoreType.Spec]);
    }

    [Test]
    public void AddDataStore_ShouldSetTheScenaroDataStore_WhenCalledForScenarioDataStoreType()
    {
        DataStoreFactory.AddDataStore(1, DataStoreType.Scenario);
        Assert.IsNotNull(DataStoreFactory.GetDataStoresByStream(1)[DataStoreType.Scenario]);
    }

    [Test]
    public void AddDataStore_ShouldKeepSeparateDataStores_WhenCalledForDifferentStreams()
    {
        DataStoreFactory.AddDataStore(1, DataStoreType.Scenario);
        DataStoreFactory.AddDataStore(2, DataStoreType.Scenario);
        var dict1 = DataStoreFactory.GetDataStoresByStream(1)[DataStoreType.Scenario];
        var dict2 = DataStoreFactory.GetDataStoresByStream(2)[DataStoreType.Scenario];

        Assert.AreNotSame(dict1, dict2);
        dict1.Add("mykey", new object());
        Assert.IsNull(dict2.Get("mykey"));
    }
}