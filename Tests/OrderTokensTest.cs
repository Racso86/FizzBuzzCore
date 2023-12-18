using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class OrderTokensTest
    {
        private static Dictionary<int, string> _Tokens;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize the _Tokens dictionary before each test
            _Tokens = new Dictionary<int, string>
        {
            { 3, "Three" },
            { 1, "One" },
            { 2, "Two" },
            // Add more key-value pairs as needed
        };
        }

        [TestMethod]
        public void OrderTokens_ShouldOrderKeys()
        {
            // Act
            TwistedFizzBuzz.TwistedFizzBuzz.OrderTokens();

            // Assert
            var orderedKeys = _Tokens.Keys.ToList();
            CollectionAssert.AreEqual(orderedKeys, orderedKeys.OrderBy(k => k).ToList());
        }

        [TestMethod]
        public void OrderTokens_ShouldPreserveValues()
        {
            // Act
            TwistedFizzBuzz.TwistedFizzBuzz.OrderTokens();

            // Assert
            var orderedKeys = _Tokens.Keys.OrderBy(k => k).ToList();
            for (int i = 0; i < orderedKeys.Count; i++)
            {
                Assert.AreEqual(_Tokens[orderedKeys[i]], _Tokens.ElementAt(i).Value);
            }
        }

        private static void EmptyTokens()
        {
            _Tokens.Clear();
        }
    }
}
