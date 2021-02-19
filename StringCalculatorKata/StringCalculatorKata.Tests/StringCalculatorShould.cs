using Xunit;

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
        public void Add_StringNumbers_ReturnIntSum(string numbers, int expectedSum)
        {
            var stringCalculator = new StringCalculator();
            int sum = stringCalculator.add(numbers);
            Assert.Equal(expectedSum, sum);
        }
    }
}
