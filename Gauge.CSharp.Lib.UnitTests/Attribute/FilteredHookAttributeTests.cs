using Gauge.CSharp.Lib.Attribute;

namespace Gauge.CSharp.Lib.UnitTests.Attribute
{
    [TestFixture]
    public class FilteredHookAttributeTests
    {
        public class TestHookAttribute : FilteredHookAttribute
        {
            public TestHookAttribute()
            {
            }

            public TestHookAttribute(string filterTag) : base(filterTag)
            {
            }

            public TestHookAttribute(params string[] filterTags) : base(filterTags)
            {
            }
        }

        [Test]
        public void ShouldCreateAttributeWithMultipleTags()
        {
            var filterTags = new[] { "foo", "bar" };
            var filteredHookAttribute = new TestHookAttribute(filterTags);

            foreach (var filterTag in filterTags)
                Assert.That(filteredHookAttribute.FilterTags, Does.Contain(filterTag));
        }

        [Test]
        public void ShouldCreateAttributeWithNoParameters()
        {
            var filteredHookAttribute = new TestHookAttribute();
            Assert.That(filteredHookAttribute, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAttributeWithOneTag()
        {
            var filterTag = "foo";
            var filteredHookAttribute = new TestHookAttribute(filterTag);
            Assert.That(filteredHookAttribute.FilterTags, Does.Contain(filterTag));
        }
    }
}