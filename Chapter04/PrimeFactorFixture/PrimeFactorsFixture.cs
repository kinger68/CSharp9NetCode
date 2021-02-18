using NUnit.Framework;
using PrimeFactors;
using Rhino.Mocks;

namespace Tests
{
    public class PrimeFactorFixture
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(4, "2,2")]
        [TestCase(7, "7,1")]
        [TestCase(30, "5,3,2")]
        [TestCase(40, "5,2,2,2")]
        [TestCase(50, "5,5,2")]
        public void CalculateFactors_PrimeFactors_ExpectedFactors(int number, string result)
        {
            // Arrange
            // Act
            var primeFactorResults = PrimeFactor.PrimeFactors(number);

            // Assume
            Assert.AreEqual(result, primeFactorResults);
        }
    }
}