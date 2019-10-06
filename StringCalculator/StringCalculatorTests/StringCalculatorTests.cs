﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void AddTest_DoubleNumberCommaDelimitedString_Success()
        {
            // Arrange 
            var numbers = "1,2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberCommaDelimitedString_Success()
        {
            // Arrange 
            var numbers = "1,2,3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_MultipleNumberCommaDelimitedString_Success()
        {
            // Arrange 
            var total = 0;
            var sb = new StringBuilder();
            var random = new Random();
            var totalNumbers = random.Next(1, 100);
            var counter = 0;

            while(counter < totalNumbers)
            {
                var number = random.Next(1, 100);

                if(counter == 0)
                {
                    sb.Append(number);
                }
                else
                {
                    sb.AppendFormat(",{0}", number);
                }

                total += number;
                counter++;
            }

            var numbers = sb.ToString();

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(total, result);
        }


        [TestMethod()]
        public void AddTest_DoubleNumberNewLineDelimiterString_Success()
        {
            // Arrange 
            var numbers = "1\n2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberNewLineDelimiterString_Success()
        {
            // Arrange 
            var numbers = "1\n2\n3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_SingleNumberInvalidDelimiterString_Failure()
        {
            // Arrange 
            var numbers = "1,\n";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException ex)
            {
                exceptionThrown = true;
            }
            
            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_MultipleNumberNewLineDelimitedString_Success()
        {
            // Arrange 
            var total = 0;
            var sb = new StringBuilder();
            var random = new Random();
            var totalNumbers = random.Next(1, 100);
            var counter = 0;

            while (counter < totalNumbers)
            {
                var number = random.Next(1, 100);

                if (counter == 0)
                {
                    sb.Append(number);
                }
                else
                {
                    sb.AppendFormat("\n{0}", number);
                }

                total += number;
                counter++;
            }

            var numbers = sb.ToString();

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(total, result);
        }
    }
}