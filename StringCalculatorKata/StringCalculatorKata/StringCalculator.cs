using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private string _numbers;
        private List<char> _delimiters = new List<char>() { ',', '\n' };

        public int add(string numbers)
        {
            _numbers = numbers;
            _checkForCustumDelimiter();
            if (_numbers == "")
                return 0;
            return _numbers.Split(_delimiters.ToArray()).Select((num) => int.Parse(num)).Sum();
        }

        private void _checkForCustumDelimiter()
        {
            bool isDelimmeterSpecified = _numbers.StartsWith("//");
            if (isDelimmeterSpecified == true)
            {
                char customDelimiter = _numbers.Substring(2, 1).ToCharArray()[0];
                _delimiters.Add(customDelimiter);
                _numbers = _numbers.Substring(4);
            }
        }
    }
}
