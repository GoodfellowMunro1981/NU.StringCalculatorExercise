using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            while (counter < totalNumbers)
            {
                var number = random.Next(1, 100);

                if (counter == 0)
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
            catch (InvalidDelimiterException)
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

        [TestMethod()]
        public void AddTest_DoubleNumberSupportCustomDelimitedString1_Success()
        {
            // Arrange 
            var numbers = "//;\n1;2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_DoubleNumberSupportCustomDelimitedString1_Failure()
        {
            // Arrange 
            var numbers = "//;\n;1;2";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberSupportCustomDelimitedString1_Success()
        {
            // Arrange 
            var numbers = "//;\n1;2;3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberSupportCustomDelimitedString1_Failure()
        {
            // Arrange 
            var numbers = "//;\n;1;2;3";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }


        [TestMethod()]
        public void AddTest_DoubleNumberSupportCustomDelimitedString2_Success()
        {
            // Arrange 
            var numbers = "//#\n1#2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_DoubleNumberSupportCustomDelimitedString2_Failure()
        {
            // Arrange 
            var numbers = "//#\n1##2";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberSupportCustomDelimitedString2_Success()
        {
            // Arrange 
            var numbers = "//#\n1#2#3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberSupportCustomDelimitedString2_Failure()
        {
            // Arrange 
            var numbers = "//#\n1##2#3";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_DoubleNumberContainingNegativeString_Failure()
        {
            // Arrange 
            var numbers = "//#\n1#-2";
            var negativeNumberExceptionThrown = false;
            var negativeNumberExceptionMessage = default(string);

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (NegativeNumberException ex)
            {
                negativeNumberExceptionThrown = true;
                negativeNumberExceptionMessage = ex.Message;
            }

            // Assert
            Assert.AreEqual(negativeNumberExceptionThrown, true);
            StringAssert.Contains(negativeNumberExceptionMessage, "-2");
        }

        [TestMethod()]
        public void AddTest_TrebleNumberContainingNegativeString_Failure()
        {
            // Arrange 
            var numbers = "//#\n1#-2#3";
            var negativeNumberExceptionThrown = false;
            var negativeNumberExceptionMessage = default(string);

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (NegativeNumberException ex)
            {
                negativeNumberExceptionThrown = true;
                negativeNumberExceptionMessage = ex.Message;
            }

            // Assert
            Assert.AreEqual(negativeNumberExceptionThrown, true);
            StringAssert.Contains(negativeNumberExceptionMessage, "-2");
        }

        [TestMethod()]
        public void AddTest_DoubleNumberContainingNumberGreaterThan1000String_Success()
        {
            // Arrange 
            var numbers = "1,1001";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberContainingNumberGreaterThan1000String_Failure()
        {
            // Arrange 
            var numbers = "1,1002,2";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthDelimitedString1_Success()
        {
            // Arrange 
            var numbers = "//[***]\n1***2***3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthDelimitedString1_Failure()
        {
            // Arrange 
            var numbers = "//[***]\n1*2**3";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthDelimitedString2_Success()
        {
            // Arrange 
            var numbers = "//[@@@]\n1@@@2@@@3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthDelimitedString2_Failure()
        {
            // Arrange 
            var numbers = "//[@@@]\n1@2@@3";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthDelimitedString3_Success()
        {
            // Arrange 
            var numbers = "//[***]\n1,2,3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthMultiDelimitedString1_Success()
        {
            // Arrange 
            var numbers = "//[*][%]\n1*2%3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthMultiDelimitedString2_Success()
        {
            // Arrange 
            var numbers = "//[@][%]\n1@2%3";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthMultiDelimitedString2_Failure()
        {
            // Arrange 
            var numbers = "//[@][%]\n1*@2%3";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthMultiDelimitedString3_Success()
        {
            // Arrange 
            var numbers = "//[@@@][%%][*]\n1@@@2%%3*4,5";

            // Act
            var result = StringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void AddTest_TrebleNumberAnyLengthMultiDelimitedString3_Failure()
        {
            // Arrange 
            var numbers = "//[@@@][%%][*]\n1*@2%3*4,5";
            var exceptionThrown = false;

            // Act
            try
            {
                var result = StringCalculator.Add(numbers);
            }
            catch (InvalidDelimiterException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.AreEqual(exceptionThrown, true);
        }
    }
}