using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FizzBuzzValue_ReturnsFizzBuzz_WhenInputIsDivisibleByBoth3And5()
        {
            // Arrange
            long input = 15; // Example input divisible by both 3 and 5

            // Act
            string result = TwistedFizzBuzz.TwistedFizzBuzz.FizzBuzzValue(input);

            // Assert
            Assert.AreEqual("FizzBuzz\n", result);
        }

        [TestMethod]
        public void FizzBuzzValue_ReturnsFizz_WhenInputIsDivisibleBy3()
        {
            // Arrange
            long input = 9; // Example input divisible by 3

            // Act
            string result = TwistedFizzBuzz.TwistedFizzBuzz.FizzBuzzValue(input);

            // Assert
            Assert.AreEqual("Fizz\n", result);
        }

        [TestMethod]
        public void FizzBuzzValue_ReturnsBuzz_WhenInputIsDivisibleBy5()
        {
            // Arrange
            long input = 10; // Example input divisible by 5

            // Act
            string result = TwistedFizzBuzz.TwistedFizzBuzz.FizzBuzzValue(input);

            // Assert
            Assert.AreEqual("Buzz\n", result);
        }

        [TestMethod]
        public void FizzBuzzValue_ReturnsInputAsString_WhenInputIsNotDivisibleBy3Or5()
        {
            // Arrange
            long input = 7; // Example input not divisible by 3 or 5

            // Act
            string result = TwistedFizzBuzz.TwistedFizzBuzz.FizzBuzzValue(input);

            // Assert
            Assert.AreEqual("7\n", result);
        }
    }
}
