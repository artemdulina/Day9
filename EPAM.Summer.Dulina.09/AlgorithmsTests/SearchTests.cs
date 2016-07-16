using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTests
{

    [TestFixture]
    public class SearchTests
    {
        [Test]
        [TestCase(new double[] { -5.8, 0, 2, 8, 10.6, 12, 300, 500 }, 10.6, ExpectedResult = 4)]
        [TestCase(new double[] { -5.8, 0, 2, 8, 10.6, 12, 300, 500 }, 10.7, ExpectedResult = -1)]
        public int BinarySearchTest_DoubleValueToSearchWithDefaultComparator_ShouldReturnCorrectIndex(double[] array, double value)
        {
            return Search.BinarySearch(array, value);
        }

        [Test]
        [TestCase(new double[] { -5.8, 0, 2, 8, 10.6, 12, 300, 500 }, -5.8, ExpectedResult = 0)]
        [TestCase(new double[] { -300, -5.8, 0, 2, 8, 10.6, 12, 500 }, 500, ExpectedResult = 7)]
        public int BinarySearchTest_DoubleValueToSearchWithModuleComparator_ShouldReturnCorrectIndex(double[] array, double value)
        {
            return Search.BinarySearch(array, value, new RisingSort());
        }

        [Test]
        [TestCase(new string[] { "a", "ab", "abc", "string" }, "abc", ExpectedResult = 2)]
        [TestCase(new string[] { "a", "ab", "abc", "string" }, "abcd", ExpectedResult = -1)]
        public int BinarySearchTest_StringValueToSearchWithDefaultComparator_ShouldReturnCorrectIndex(string[] array, string value)
        {
            return Search.BinarySearch(array, value);
        }
    }
}