using Xunit;
using System;
namespace StringCalculatorKata.Tests
{
    public class StringCalculatorShould
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//*\n2*3", 5)]
        [InlineData("//$\n6$1,1", 8)]
        [InlineData("6,1,1,1000,2000", 1008)]
        public void Add_StringNumbers_ReturnIntSum(string numbers, int expectedSum)
        {
            int sum = StringCalculator.add(numbers);
            Assert.Equal(expectedSum, sum);
        }

        [Theory]
        [InlineData("1,-2,-3", "negatives not allowed: -2, -3, ")]
        [InlineData("1,2,3,92,-100", "negatives not allowed: -100, ")]
        public void Add_WithNegativeNumbers_ThrowsException(string numbers, string exceptionMessage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => StringCalculator.add(numbers));
            Assert.Equal(exceptionMessage, ex.Message);
        }

        [Theory]
        [InlineData("6,1,1,1000,,2000")]
        [InlineData("10001,\n2000")]
        [InlineData("10001,a,2000")]
        [InlineData("10001,,2000")]
        [InlineData(",")]
        public void Add_InvalidInputStringFormat_ReturnZero(string numbers)
        {
            int sum = StringCalculator.add(numbers);
            Assert.Equal(0, sum);
        }
    }
}
