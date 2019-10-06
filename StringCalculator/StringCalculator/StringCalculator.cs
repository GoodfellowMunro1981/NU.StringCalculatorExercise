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
            if (numbers.Any(x => x < 0))
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

                throw new NegativeNumberException(sb.ToString());
            }
        }

        private static NumberStringModel GetDelimiterAndNumberString(string numbers)
        {
            var delimiters = new List<string>();

            foreach (var delimiter in DEFAULT_DELIMITERS)
            {
                delimiters.Add(delimiter);
            }

            if (numbers.StartsWith(("//")))
            {
                foreach (var arrayItem in numbers.Split('\n'))
                {
                    if (arrayItem.StartsWith("//"))
                    {
                        var delimiterString = arrayItem
                                                .Replace("//", string.Empty);

                        if (delimiterString.StartsWith("[") && delimiterString.EndsWith("]"))
                        {
                            Regex regex = new Regex("\\[(.*?)\\]");
                            Match match = regex.Match(delimiterString);

                            if(match.Success)
                            {
                                delimiters.Add(match.Groups[1].ToString());
                            }
                        }
                        else
                        {
                            delimiters.Add(delimiterString);
                        }
                    }
                    else
                    {
                        numbers = arrayItem;
                    }
                }
            }

            return new NumberStringModel
            {
                Delimiters = delimiters.ToArray(),
                Numbers = numbers
            };
        }
    }
}
