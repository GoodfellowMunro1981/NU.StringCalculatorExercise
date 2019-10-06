namespace StringCalculator
{
    public static class StringCalculator
    {
        private static char[] DEFAULT_DELIMITERS = new char[] { ',', '\n' };
        private static string INVALID_DELIMITER_MESSAGE = "String numbers contains invalid delimiter.";

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
                    else
                    {
                        throw new InvalidDelimiterException(INVALID_DELIMITER_MESSAGE);
                    }
                }
            }

            return total;
        }
    }
}
