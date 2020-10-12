/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using NUnit.Framework;
using System.Collections.Generic;

namespace Gauge.CSharp.Lib.UnitTests
{
    [TestFixture]
    public class SuiteSpecAndScenarioDataStoreTests
    {
        [Test]
        public void ScenarioDataStoreTestAdd()
        {
            ScenarioDataStore.Add("myKey1", "myValue");
            Assert.AreEqual(ScenarioDataStore.Get("myKey1"), "myValue");
        }

        [Test]
        public void ScenarioDataStoreTestAddObject()
        {
            var obj = new List<string>() { "val1" };
            ScenarioDataStore.Add("myKey2", obj);
            Assert.AreEqual(ScenarioDataStore.Get("myKey2"), obj);
            Assert.IsInstanceOf<List<string>>(ScenarioDataStore.Get("myKey2"));
        }

        [Test]
        public void SpecDataStoreTestAdd()
        {
            SpecDataStore.Add("myKey3", "myValue");
            Assert.AreEqual(SpecDataStore.Get("myKey3"), "myValue");
        }

        [Test]
        public void SpecDataStoreTestAddObject()
        {
            var obj = new List<string>() { "val1" };
            SpecDataStore.Add("myKey4", obj);
            Assert.AreEqual(SpecDataStore.Get("myKey4"), obj);
            Assert.IsInstanceOf<List<string>>(SpecDataStore.Get("myKey4"));
        }

        [Test]
        public void SuiteDataStoreTestAdd()
        {
            SuiteDataStore.Add("myKey5", "myValue");
            Assert.AreEqual(SuiteDataStore.Get("myKey5"), "myValue");
        }

        [Test]
        public void SuiteDataStoreTestAddObject()
        {
            var obj = new List<string>() { "val1" };
            SuiteDataStore.Add("myKey6", obj);
            Assert.AreEqual(SuiteDataStore.Get("myKey6"), obj);
            Assert.IsInstanceOf<List<string>>(SuiteDataStore.Get("myKey6"));
        }

        [Test]
        public void AllDataStoreTestAdd()
        {
            ScenarioDataStore.Add("myKey7", "scenario");
            SpecDataStore.Add("myKey7", "spec");
            SuiteDataStore.Add("myKey7", "suite");
            Assert.AreEqual(ScenarioDataStore.Get("myKey7"), "scenario");
            Assert.AreEqual(SpecDataStore.Get("myKey7"), "spec");
            Assert.AreEqual(SuiteDataStore.Get("myKey7"), "suite");
        }

        [Test]
        public void AllDataStoreTestAddObject()
        {
            var obj1 = new List<string>() { "scenario" };
            var obj2 = new List<string>() { "spec" };
            var obj3 = new List<string>() { "suite" };
            ScenarioDataStore.Add("myKey8", obj1);
            Assert.AreEqual(ScenarioDataStore.Get("myKey8"), obj1);
            Assert.IsInstanceOf<List<string>>(ScenarioDataStore.Get("myKey8"));
            SpecDataStore.Add("myKey8", obj2);
            Assert.AreEqual(SpecDataStore.Get("myKey8"), obj2);
            Assert.IsInstanceOf<List<string>>(SpecDataStore.Get("myKey8"));
            SuiteDataStore.Add("myKey8", obj3);
            Assert.AreEqual(SuiteDataStore.Get("myKey8"), obj3);
            Assert.IsInstanceOf<List<string>>(SuiteDataStore.Get("myKey8"));
        }
    }
}