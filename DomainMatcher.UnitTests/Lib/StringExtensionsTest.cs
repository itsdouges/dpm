using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainMatcher.Lib;

namespace DomainMatcher.UnitTests.Lib
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void ShouldRemovePunctuation()
        {
            var text = "*Super*High! APARTMENTS ,(Sydney)";

            var actual = text.CleanPunctuation();

            Assert.AreEqual("SuperHigh APARTMENTS Sydney", actual);
        }

        [TestMethod]
        public void ShouldReplaceDashesWithSpaces()
        {
            var text = "Apartments Summit The";

            var actual = text.ReverseWords();

            Assert.AreEqual("The Summit Apartments", actual);
        }
    }
}
