using System;
using PaySlip.Kata;
using Xunit;

namespace PaySlip.Test
{
    public class PaySlipKataTest
    {
        readonly PaySlipManager paySlip = new PaySlipManager();
        //Acceptance Test

        [Theory]
        [InlineData(15000, 1250)]
        [InlineData(18000, 1500)]
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

        [Theory]
        [InlineData(5004, 9, 450)]
        [InlineData(6150, 7, 430)]
        [InlineData(7010, 8, 560)]
        public void GivenGrossIncomeIsAPositiveValueWhenSuperIsCalculatedThenReturnSuperRoundedDown(int grossIncome,
            int superRate, int actualSuper)
        {
            var expectedSuper = paySlip.CalculateSuper(grossIncome, superRate);

            Assert.Equal(expectedSuper, actualSuper);
        }

        [Theory]
        [InlineData(5004, 922, 4082)]
        [InlineData(5833, 950, 4883)]
        public void GivenGrossIncomeIsCalculatedWhenNetIncomeIsCalculatedThenReturnNetIcome(int grossIncome,
            int incomeTax, int actualNetIncome)
        {
            var expectedNetIncome = paySlip.CalculateNetIncome(grossIncome, incomeTax);

            Assert.Equal(expectedNetIncome, actualNetIncome);
        }
    }
}