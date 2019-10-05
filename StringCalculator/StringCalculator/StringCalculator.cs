using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private static char[] DEFAULT_DELIMITERS = new char[] { ',' };

        public static int Add(string numbers)
        {
            int total = 0;

            if(!string.IsNullOrEmpty(numbers))
            {
                string[] numberValues = numbers.Split(DEFAULT_DELIMITERS);

                foreach (var numberValue in numberValues)
                {
                    if (int.TryParse(numberValue, out int number))
                    {
                        total += number;
                    }
                }
            }

            return total;
        }
    }
}
