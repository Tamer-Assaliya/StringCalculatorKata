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
            List<int> numericNums = numbers.Split(usedDelimiters.ToArray()).Select((num) => int.Parse(num)).ToList();
            List<int> negativeNumbers = numericNums.Where((num) => num < 0).ToList();
            if (negativeNumbers.Count > 0)
            {
                string exceptionMessage = "negatives not allowed: ";
                negativeNumbers.ForEach((negativeNum) => { exceptionMessage += $"{negativeNum}, "; });
                throw new ArgumentException(exceptionMessage);
            }
            return numericNums.Sum();
        }
    }
}
