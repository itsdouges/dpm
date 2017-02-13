using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainMatcher.UnitTests.Matchers
{
    [TestClass]
    public class MatchOtbreTest
    {
        protected IPropertyMatcher matcher;

        [TestInitialize]
        public void Setup()
        {
            matcher = new MatchOtbre();
        }

        [TestMethod]
        public void ShouldMatchWithPunctuation()
        {
            var agencyProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney NSW"
            };

            var dbProperty = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldNotMatchDifferentNameAddress()
        {
            var agencyProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney NSW"
            };

            var dbProperty = new Property()
            {
                Name = "Neat Living Place, CHEAP CHEAP!",
                Address = "5 Help Street, Chatswood NSW"
            };

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
        }
    }
}
