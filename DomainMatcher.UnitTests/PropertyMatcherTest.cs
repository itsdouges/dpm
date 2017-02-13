using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DomainMatcher.UnitTests
{
    [TestClass]
    public class PropertyMatcherTest
    {
        private IPropertyMatcher matcher;
        private Mock<IPropertyMatcher> matcherOne;
        private Mock<IPropertyMatcher> matcherTwo;

        [TestInitialize]
        public void Setup()
        {
            matcherOne = new Mock<IPropertyMatcher>();
            matcherTwo = new Mock<IPropertyMatcher>();

            var matchers = new List<IPropertyMatcher>()
            {
                matcherOne.Object,
                matcherTwo.Object
            };

            matcher = new PropertyMatcher(matchers);
        }

        [TestMethod]
        public void ShouldIterateThoughAllIfAMatchWasntFound()
        {
            var agencyProperty = new Property();
            var dbProperty = new Property();

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsFalse(actual);
            matcherOne.Verify(obj => obj.IsMatch(agencyProperty, dbProperty));
            matcherTwo.Verify(obj => obj.IsMatch(agencyProperty, dbProperty));
        }

        [TestMethod]
        public void ShouldReturnImmediatelyIfAMatchWasFound()
        {
            var agencyProperty = new Property();
            var dbProperty = new Property();
            matcherOne.Setup(obj => obj.IsMatch(agencyProperty, dbProperty)).Returns(true);

            var actual = matcher.IsMatch(agencyProperty, dbProperty);

            Assert.IsTrue(actual);
            matcherTwo.Verify(obj => obj.IsMatch(agencyProperty, dbProperty), Times.Never);
        }
    }
}
