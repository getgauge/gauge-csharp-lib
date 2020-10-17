/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public void AllDataStoreTestClean()
        {
            ScenarioDataStore.Add("myKey7", "scenario");
            SpecDataStore.Add("myKey7", "spec");
            SuiteDataStore.Add("myKey7", "suite");
            Assert.AreEqual(ScenarioDataStore.Get("myKey7"), "scenario");
            Assert.AreEqual(SpecDataStore.Get("myKey7"), "spec");
            Assert.AreEqual(SuiteDataStore.Get("myKey7"), "suite");
            ScenarioDataStore.Clear();
            SpecDataStore.Clear();
            SuiteDataStore.Clear();
            Assert.IsNull(ScenarioDataStore.Get("myKey7"));
            Assert.IsNull(SpecDataStore.Get("myKey7"));
            Assert.IsNull(SuiteDataStore.Get("myKey7"));
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

        [Test]
        public void ScenarioDataStoreParallelInvoke()
        {
            Task.WaitAll( new Task[6]
            {
                Task.Run(() => ScenarioDataStore.Add("sckey1", "Scenario1"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey1"), "Scenario1")),
                Task.Run(() => ScenarioDataStore.Add("sckey2", "Scenario2"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey2"), "Scenario2")),
                Task.Run(() => ScenarioDataStore.Add("sckey3", "Scenario3"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey3"), "Scenario3")),
                Task.Run(() => ScenarioDataStore.Add("sckey4", "Scenario4"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey4"), "Scenario4")),
                Task.Run(() => ScenarioDataStore.Add("sckey5", "Scenario5"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey5"), "Scenario5")),
                Task.Run(() => ScenarioDataStore.Add("sckey6", "Scenario6"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey6"), "Scenario6"))
            });
        }

        [Test]
        public void AllDataStoreParallelInvoke()
        {
            Task.WaitAll( new Task[12]
            {
                Task.Run(() => ScenarioDataStore.Add("sckey7", "Scenario7"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey7"), "Scenario7")),

                Task.Run(() => ScenarioDataStore.Add("sckey8", "Scenario8"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey8"), "Scenario8")),

                Task.Run(() => ScenarioDataStore.Add("sckey9", "Scenario9"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey9"), "Scenario9")),

                Task.Run(() => ScenarioDataStore.Add("sckey10", "Scenario10"))
                .ContinueWith((o) => Assert.AreEqual(ScenarioDataStore.Get("sckey10"), "Scenario10")),

                Task.Run(() => SpecDataStore.Add("spec1", "Spec1"))
                .ContinueWith((o) => Assert.AreEqual(SpecDataStore.Get("spec1"), "Spec1")),

                Task.Run(() => SpecDataStore.Add("spec2", "Spec2"))
                .ContinueWith((o) => Assert.AreEqual(SpecDataStore.Get("spec2"), "Spec2")),

                Task.Run(() => SpecDataStore.Add("spec3", "Spec3"))
                .ContinueWith((o) => Assert.AreEqual(SpecDataStore.Get("spec3"), "Spec3")),

                Task.Run(() => SpecDataStore.Add("spec4", "Spec4"))
                .ContinueWith((o) => Assert.AreEqual(SpecDataStore.Get("spec4"), "Spec4")),

                Task.Run(() => SuiteDataStore.Add("suite1", "Suite1"))
                .ContinueWith((o) => Assert.AreEqual(SuiteDataStore.Get("suite1"), "Suite1")),

                Task.Run(() => SuiteDataStore.Add("suite2", "Suite2"))
                .ContinueWith((o) => Assert.AreEqual(SuiteDataStore.Get("suite2"), "Suite2")),

                Task.Run(() => SuiteDataStore.Add("suite3", "Suite3"))
                .ContinueWith((o) => Assert.AreEqual(SuiteDataStore.Get("suite3"), "Suite3")),

                Task.Run(() => SuiteDataStore.Add("suite4", "Suite4"))
                .ContinueWith((o) => Assert.AreEqual(SuiteDataStore.Get("suite4"), "Suite4"))
            });
        }
    }
}