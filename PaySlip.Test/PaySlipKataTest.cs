using System;
using PaySlip.Kata;
using Xunit;

namespace PaySlip.Test
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

//        [Theory]
////        [InlineData(15600, 0, 0, 0, 15600)]
//        [InlineData(60050, 37000, 0.325, 3572, 922)]
//        [InlineData(90100, 87000, 0.37, 19822, 1747)]
//        [InlineData(185500, 180000, 0.45, 54232, 4726)]
//        public void GivenAnnualSalaryIsAPositiveValueWhenIncomeTaxCalculatedThenReturnIncomeTaxRoundedUp(
//            int annualSalary, int minimumTaxableSalary, decimal taxPerDollar, int extraTax, int actualTotalIncomeTax)
//        {
//            var expectedTotalIncomeTax = paySlip.CalculateIncomeTax(annualSalary, taxPerDollar, extraTax);
//
//            Assert.Equal(expectedTotalIncomeTax, actualTotalIncomeTax);
//        }

        [Theory]
//        [InlineData(15600, 0, 0, 15600)]
        [InlineData(60050, 0.325, 3572, 922)]
        [InlineData(90100, 0.37, 19822, 1747)]
        [InlineData(185500, 0.45, 54232, 4726)]
        public void GivenAnnualSalaryIsAPositiveValueWhenIncomeTaxCalculatedThenReturnIncomeTaxRoundedUpV2(
            int annualSalary, decimal taxPerDollar, int extraTax, int actualTotalIncomeTax)
        {
            var expectedTotalIncomeTax = paySlip.CalculateIncomeTax(annualSalary, extraTax);

            Assert.Equal(expectedTotalIncomeTax, actualTotalIncomeTax);
        }
    }
}