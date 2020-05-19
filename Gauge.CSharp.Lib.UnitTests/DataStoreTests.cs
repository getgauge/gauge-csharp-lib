/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using NUnit.Framework;

namespace Gauge.CSharp.Lib.UnitTests
{
    [TestFixture]
    public class DataStoreTests
    {
        [SetUp]
        public void Setup()
        {
            _dataStore = new DataStore();
            _dataStore.Initialize();
        }

        public class Fruit
        {
            public string Name { get; set; }
        }

        private DataStore _dataStore;

        [Test]
        public void ShouldClearDataStore()
        {
            _dataStore.Add("fruit", "apple");
            _dataStore.Clear();

            Assert.AreEqual(_dataStore.Count, 0);
        }

        [Test]
        public void ShouldGetNullWhenKeyDoesNotExist()
        {
            _dataStore.Add("fruit", "banana");
            var fruit = _dataStore.Get("banana");

            Assert.IsNull(fruit);
        }

        [Test]
        public void ShouldGetStrongTypedValue()
        {
            _dataStore.Add("banana", new Fruit {Name = "Banana"});
            var fruit = _dataStore.Get<Fruit>("banana");

            Assert.IsInstanceOf<Fruit>(fruit);
            Assert.AreEqual("Banana", fruit.Name);
        }

        [Test]
        public void ShouldInitializeDataStore()
        {
            Assert.AreEqual(_dataStore.Count, 0);
        }

        public class Sample
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }

        [Test]
        public void ShouldInsertComplexTypeIntoDataStore()
        {

            _dataStore.Add("bar", new Sample {Name = "Hello", Country = "India"});
            var value = _dataStore.Get("bar") as Sample;

            Assert.AreEqual(value.Name, "Hello");
        }

        [Test]
        public void ShouldInsertValueIntoDataStore()
        {
            _dataStore.Add("foo", 23);

            Assert.AreEqual(_dataStore.Count, 1);
            Assert.AreEqual(_dataStore.Get("foo"), 23);
        }

        [Test]
        public void ShouldRaiseInvalidCastExceptionWhenAskingForInvalidCast()
        {
            _dataStore.Add("banana", new Fruit {Name = "Banana"});

            Assert.Throws<InvalidCastException>(() => { _dataStore.Get<string>("banana"); });
        }

        [Test]
        public void ShouldReturnNullWhenAskingForInvalidKeyWithStrongType()
        {
            _dataStore.Add("banana", new Fruit {Name = "Banana"});

            var fruit = _dataStore.Get<Fruit>("random");

            Assert.IsNull(fruit);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenKeyIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { _dataStore.Get(null); });
        }

        [Test]
        public void ShouldUpdateDataForGivenKey()
        {
            _dataStore.Add("foo", "bar");
            _dataStore.Add("foo", "rumpelstiltskin");

            var value = _dataStore.Get("foo");

            Assert.AreEqual(value, "rumpelstiltskin");
        }
    }
}