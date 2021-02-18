using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int add(String numbers)
        {
            if (numbers == "")
                return 0;
            return numbers.Split(',').Select((num) => int.Parse(num)).Sum();
        }
    }
}
