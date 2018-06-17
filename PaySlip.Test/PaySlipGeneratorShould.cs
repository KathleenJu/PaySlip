using PaySlip.Kata;
using Xunit;

namespace PaySlip.Test
{
    public class PaySlipGeneratorShould
    {
        [Theory]
        [InlineData("Joe", "test")]
        public void StoreTheUserInputInAnArray(string input, string actualOutput)
        {
            var foo = new PaySlipGenerator();
            var expectedOutput = foo.GeneratePaySlipFormV2();
            
            Assert.Equal();
        }
    }
}