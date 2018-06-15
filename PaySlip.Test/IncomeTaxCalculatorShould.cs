using PaySlip.Kata;
using Xunit;

namespace PaySlip.Test
{
    public class IncomeTaxCalculatorShould
    {
        [Theory]
        [InlineData(15600, 0)]
        [InlineData(18200, 0)]
        [InlineData(25750, 120)]
        [InlineData(37000, 298)]
        [InlineData(37001, 298)]
        [InlineData(60050, 922)]
        [InlineData(87001, 1652)]
        [InlineData(90100, 1747)]
        [InlineData(185500, 4726)]
        public void GivenAnnualSalaryIsAPositiveValueWhenIncomeTaxCalculatedThenReturnIncomeTaxRoundedUp(
            int annualSalary, int actualTotalIncomeTax)
        {
            var incomeTax = new IncomeTaxCalculator(annualSalary);
            var expectedTotalIncomeTax = incomeTax.CalculateIncomeTax();

            Assert.Equal(expectedTotalIncomeTax, actualTotalIncomeTax);
        }
    }
}