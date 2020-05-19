/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using NUnit.Framework;

namespace Gauge.CSharp.Lib.UnitTests
{
    [TestFixture]
    public class DataStoreFactoryTests
    {
        [Test]
        public void ShouldBeAbleToStoreValuesToDatastoreWithoutInitializing()
        {
            var dataStore = DataStoreFactory.ScenarioDataStore;
            dataStore.Add("myKey", "myValue");
            Assert.AreEqual(dataStore.Get("myKey"), "myValue");
        }

        [Test]
        public void ShouldGetDataStoreForScenario()
        {
            var dataStore = DataStoreFactory.ScenarioDataStore;

            Assert.NotNull(dataStore);
            Assert.IsInstanceOf<DataStore>(dataStore);
        }

        [Test]
        public void ShouldGetDataStoreForSpec()
        {
            var dataStore = DataStoreFactory.SpecDataStore;

            Assert.NotNull(dataStore);
            Assert.IsInstanceOf<DataStore>(dataStore);
        }

        [Test]
        public void ShouldGetDataStoreForSuite()
        {
            var dataStore = DataStoreFactory.SuiteDataStore;

            Assert.NotNull(dataStore);
            Assert.IsInstanceOf<DataStore>(dataStore);
        }
    }
}