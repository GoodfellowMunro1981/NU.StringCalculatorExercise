using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Tests
{
    [TestClass()]
    public class StringCalculatorTests
    {
        [TestMethod()]
        public void AddTest_EmptyString_Success()
        {
            // Arrange 
            var numbers = default(string);

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void AddTest_SingleNumberString_Success()
        {
            // Arrange 
            var numbers = "1";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void AddTest_DoubleNumberString_Success()
        {
            // Arrange 
            var numbers = "1, 2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberString_Success()
        {
            // Arrange 
            var numbers = "1, 2, 3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }
    }
}