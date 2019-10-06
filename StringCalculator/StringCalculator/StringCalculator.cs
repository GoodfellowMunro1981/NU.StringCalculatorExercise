using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private static readonly char[] DEFAULT_DELIMITERS = new char[] { ',', '\n' };
        private static readonly string INVALID_DELIMITER_MESSAGE = "String numbers contains invalid delimiter.";

        public static int Add(string numbers)
        {
            int total = 0;

            if(!string.IsNullOrEmpty(numbers))
            {
                var model = GetDelimiterAndNumberString(numbers);
                var numberValues = model.Numbers.Split(model.Delimiters);

                foreach (var numberValue in numberValues)
                {
                    if (int.TryParse(numberValue, out int number))
                    {
                        total += number;
                    }
                    else
                    {
                        throw new InvalidDelimiterException(INVALID_DELIMITER_MESSAGE);
                    }
                }
            }

            return total;
        }

        private static NumberStringModel GetDelimiterAndNumberString(string numbers)
        {
            var delimiters = new List<char>();

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
                        var delimiter = arrayItem
                                        .Replace("//", "")
                                        .ToCharArray()
                                        .First();


                        delimiters.Add(delimiter);
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
