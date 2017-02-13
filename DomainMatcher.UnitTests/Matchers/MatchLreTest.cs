using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainMatcher.UnitTests.Matchers
{
    [TestClass]
    public class MatchLreTest
    {
        protected IPropertyMatcher matcher;

        [TestInitialize]
        public void Setup()
        {
            matcher = new MatchLre();
        }

        [TestMethod]
        public void ShouldMatchNearLocation()
        {
            var agencyProperty = new Property()
            {
                AgencyCode = "LRE",
                Latitude = 33.8688M,
                Longitude = 151.2093M,
            };

            var dbProperty = new Property()
            {
                AgencyCode = "LRE",
                Latitude = 33.8690M,
                Longitude = 151.2090M,
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldNotMatchFarAwayLocation()
        {
            var agencyProperty = new Property()
            {
                AgencyCode = "LRE",
                Latitude = 33.8688M,
                Longitude = 151.2093M,
            };

            var dbProperty = new Property()
            {
                AgencyCode = "LRE",
                Latitude = 61.5240M,
                Longitude = 105.3188M,
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldNotMatchDifferentAgencyCode()
        {
            var agencyProperty = new Property()
            {
                AgencyCode = "LRE",
                Latitude = 33.8688M,
                Longitude = 151.2093M,
            };

            var dbProperty = new Property()
            {
                AgencyCode = "OTBRE",
                Latitude = 33.8690M,
                Longitude = 151.2090M,
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
        }
    }
}
