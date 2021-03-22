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
            List<int> numericNums;
            try
            {
                List<char> usedDelimiters = GetUsedDelimiters(ref numbers);
                numericNums = GetNumericNumbers(numbers, usedDelimiters);
            }
            catch
            {
                return 0;
            }
            CheckForNegativeNumbers(numericNums);
            return numericNums.Sum();
        }

        private static List<char> GetUsedDelimiters(ref string numbers)
        {
            List<char> usedDelimiters = _delimiters.ToList();
            bool isCustomDelimmeterSpecified = numbers.StartsWith("//");
            if (isCustomDelimmeterSpecified == true)
            {
                char customDelimiter = numbers.Substring(2, 1).ToCharArray()[0];
                usedDelimiters.Add(customDelimiter);
                numbers = numbers.Substring(4);
            }
            return usedDelimiters;
        }

        private static List<int> GetNumericNumbers(string numbers, List<char> usedDelimiters)
        {
            return numbers.Split(usedDelimiters.ToArray())
                                    .Select((num) => int.Parse(num))
                                    .Where((numericNum) => numericNum <= 1000)
                                    .ToList();
        }

        private static void CheckForNegativeNumbers(List<int> numericNums)
        {
            List<int> negativeNumbers = numericNums.Where((num) => num < 0).ToList();
            if (negativeNumbers.Count > 0)
            {
                string exceptionMessage = "negatives not allowed: ";
                negativeNumbers.ForEach((negativeNum) => { exceptionMessage += $"{negativeNum}, "; });
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
