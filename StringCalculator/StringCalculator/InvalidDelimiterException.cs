﻿using System;

namespace StringCalculator
{
    public class InvalidDelimiterException : Exception
    {
        public InvalidDelimiterException()
        {
        }

        public InvalidDelimiterException(string message)
            : base(message)
        {
        }

        public InvalidDelimiterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
