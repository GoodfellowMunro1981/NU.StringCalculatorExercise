using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private static readonly string[] DEFAULT_DELIMITERS = new string[] { ",", "\n" };
        private static readonly string INVALID_DELIMITER_MESSAGE = "String numbers contains invalid delimiter.";
        private static readonly string NEGATIVE_NUMBER_MESSAGE = "Negatives not allowed.";

        public static int Add(string numbers)
        {
            int total = 0;

            if (!string.IsNullOrEmpty(numbers))
            {
                var model = GetDelimiterAndNumberString(numbers);
                var numberStrings = model.Numbers.Split(model.Delimiters, StringSplitOptions.None);
                var numberValues = GetValidNumberValuesLowerThan1000(numberStrings);
                CheckForNegativeNumbers(numberValues);
                total = numberValues.Sum();
            }

            return total;
        }

        private static IEnumerable<int> GetValidNumberValuesLowerThan1000(IEnumerable<string> numberStrings)
        {
            var numberValues = new List<int>();

            foreach (var numberValue in numberStrings)
            {
                if (!int.TryParse(numberValue, out int number))
                {
                    throw new InvalidDelimiterException(INVALID_DELIMITER_MESSAGE);
                }

                if (number <= 1000)
                {
                    numberValues.Add(number);
                }
            }

            return numberValues;
        }

        private static void CheckForNegativeNumbers(IEnumerable<int> numbers)
        {
            if (!numbers.Any(x => x < 0))
            {
                return;
            }

            var message = GetNegativeNumberExceptionMessage(numbers);
            throw new NegativeNumberException(message);
        }

        private static string GetNegativeNumberExceptionMessage(IEnumerable<int> numbers)
        {
            var sb = new StringBuilder();
            sb.Append(NEGATIVE_NUMBER_MESSAGE);
            var counter = 0;

            foreach (var negativeNumber in numbers.Where(x => x < 0).ToArray())
            {
                if (counter == 0)
                {
                    sb.AppendFormat(" :{0}", negativeNumber);
                }
                else
                {
                    sb.AppendFormat(",{0}", negativeNumber);
                }
            }

            return sb.ToString();
        }

        private static NumberStringModel GetDelimiterAndNumberString(string numbers)
        {
            var numbersString = default(string);
            var delimiters = GetDefaultDelimiters();
            
            if (numbers.StartsWith(("//")))
            {
                foreach (var arrayItem in numbers.Split('\n'))
                {
                    if (arrayItem.StartsWith("//"))
                    {
                        GetDelimitersFromString(delimiters, arrayItem);
                    }
                    else if (string.IsNullOrEmpty(numbersString))
                    {
                        numbersString = arrayItem;
                    }
                    else
                    {
                        numbersString = string.Format("{0}\n{1}", numbersString, arrayItem);
                    }
                }
            }
            else
            {
                numbersString = numbers;
            }

            return new NumberStringModel
            {
                Delimiters = delimiters.ToArray(),
                Numbers = numbersString
            };
        }

        private static List<string> GetDefaultDelimiters()
        {
            var delimiters = new List<string>();

            foreach (var delimiter in DEFAULT_DELIMITERS)
            {
                delimiters.Add(delimiter);
            }

            return delimiters;
        }

        private static void GetDelimitersFromString(List<string> delimiters, string arrayItem)
        {
            var delimiterString = arrayItem.Replace("//", string.Empty);

            if (delimiterString.StartsWith("[") && delimiterString.EndsWith("]"))
            {
                var regex = new Regex("\\[(.*?)\\]");
                var matches = regex.Matches(delimiterString);

                foreach (Match match in matches)
                {
                    if (match.Groups.Count == 2)
                    {
                        delimiters.Add(match.Groups[1].ToString());
                    }
                }
            }
            else
            {
                delimiters.Add(delimiterString);
            }
        }
    }
}