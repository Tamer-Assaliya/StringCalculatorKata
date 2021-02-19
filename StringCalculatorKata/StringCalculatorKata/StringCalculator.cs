using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private static readonly char[] _delimiters = { ',', '\n' };

        public static int add(string numbers)
        {
            if (numbers == "" | numbers == null)
                return 0;
            List<char> usedDelimiters = _delimiters.ToList();
            bool isDelimmeterSpecified = numbers.StartsWith("//");
            if (isDelimmeterSpecified == true)
            {
                char customDelimiter = numbers.Substring(2, 1).ToCharArray()[0];
                usedDelimiters.Add(customDelimiter);
                numbers = numbers.Substring(4);
            }
            return numbers.Split(usedDelimiters.ToArray()).Select((num) => int.Parse(num)).Sum();
        }
    }
}
