using System;
using PaySlip;
using Xunit;

namespace PaySlipKata.Test
{
    public class PaySlipKataTest
    {
        readonly PaySlipGenerator paySlip = new PaySlipGenerator();

        [Theory]
        [InlineData("John", "Doe", "John Doe")]
        [InlineData("Peter", "Smith", "Peter Smith")]
        [InlineData("ben", "peterson", "Ben Peterson")]
        [InlineData("scarlett", "jensen", "Scarlett Jensen")]
        public void FullNameShouldBeGenerated(string firstName, string lastName, string actualFullName)
        {
            var expectedFullName = paySlip.GenerateFullName(firstName, lastName);

            Assert.Equal(expectedFullName, actualFullName);
        }

        [Theory]
        [InlineData(40000, 3333)]
        [InlineData(45000, 3750)]
        [InlineData(46210, 3850)]
        [InlineData(55540, 4628)]
        [InlineData(60150, 5012)]
        [InlineData(70000, 5833)]
        public void GivenTheAnnualSalaryIsAPositiveValueWhenGrossIncomeIsCalculatedThenReturnGrossIncomeRoundedDown(
            int annualSalary, int actualGrossIncome)
        {
            var expectedGrossIncome = paySlip.CalculateGrossIncome(annualSalary);

            Assert.Equal(expectedGrossIncome, actualGrossIncome);
        }

        [Theory]
        [InlineData("1 March", "31 March", "1 March – 31 March")]
        [InlineData("1 June", "31 June", "1 June – 31 June")]
        [InlineData("1 September", "31 September", "1 September – 31 September")]
        public void PayPeriodShouldBeGenerated(string paymentStart, string paymentEnd, string actualPaymentPeriod)
        {
            var expectedPaymentPeriod = paySlip.GeneratePaymentPeriod(paymentStart, paymentEnd);

            Assert.Equal(expectedPaymentPeriod, actualPaymentPeriod);
        }
    }
}
