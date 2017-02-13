using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainMatcher.UnitTests.Matchers
{
    [TestClass]
    public class MatchCreTest
    {
        protected IPropertyMatcher matcher;

        [TestInitialize]
        public void Setup()
        {
            matcher = new MatchCre();
        }

        [TestMethod]
        public void ShouldMatchBackwardsName()
        {
            var agencyProperty = new Property()
            {
                Name = "Apartments Summit The",
            };

            var dbProperty = new Property()
            {
                Name = "The Summit Apartments",
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldNotMatchForwardsName()
        {
            var agencyProperty = new Property()
            {
                Name = "The Summit Apartments",
            };

            var dbProperty = new Property()
            {
                Name = "The Summit Apartments",
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldNotMatchDifferentName()
        {
            var agencyProperty = new Property()
            {
                Name = "Different Summit The",
            };

            var dbProperty = new Property()
            {
                Name = "The Summit Apartments",
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
        }
    }
}
