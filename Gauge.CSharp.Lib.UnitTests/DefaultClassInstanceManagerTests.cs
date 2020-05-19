/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/

using NUnit.Framework;

namespace Gauge.CSharp.Lib.UnitTests
{
    [TestFixture]
    public class DefaultClassInstanceManagerTests
    {
        [Test]
        public void ShouldGetInstanceForType()
        {
            var type = typeof(object);
            var instance = new DefaultClassInstanceManager().Get(type);

            Assert.NotNull(instance);
            Assert.AreEqual(instance.GetType(), type);
        }

        [Test]
        public void ShouldGetMemoizedInstanceForType()
        {
            var instanceManager = new DefaultClassInstanceManager();
            var type = typeof(object);
            var instance = instanceManager.Get(type);
            var anotherInstance = instanceManager.Get(type);

            Assert.AreSame(instance, anotherInstance);
        }
    }
}