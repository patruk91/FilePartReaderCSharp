using FileHelper;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ReverseStringFromGivenWord()
        {
            string expected = "sdrow";
            string actual = "words".ReverseWord();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseStringFromGivenWordForDifferentCases()
        {
            string expected = "aBbA";
            string actual = "AbBa".ReverseWord();
            Assert.AreEqual(expected, actual);
        }
    }
}