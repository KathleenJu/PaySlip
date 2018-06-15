using System;

namespace PaySlip.Kata
{
    public class PaySlipManager
    {
        public PaySlipResult PaySlipCalculator(PersonDetails personDetails)
        {
            var fullName = personDetails.GetFullName();
            var paymentPeriod = GeneratePaymentPeriod(personDetails.PaymentStartDate, personDetails.PaymentEndDate);
            var grossIncome = CalculateGrossIncome(personDetails.AnnualSalary);
            var tax = new IncomeTaxCalculator(personDetails.AnnualSalary);
            var incomeTax = tax.CalculateIncomeTax();
            var netIncome =  CalculateNetIncome(grossIncome, (int) incomeTax);
            var super =  CalculateSuper(grossIncome, personDetails.SuperRate);

            return new PaySlipResult(fullName, paymentPeriod, grossIncome,
                incomeTax,
                netIncome, super);
        }

        public int CalculateGrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;
            return grossIncome;
        }

        public string GeneratePaymentPeriod(string paymentStart, string paymentEnd)
        {
            var paymentPeriod = paymentStart + " – " + paymentEnd;
            return paymentPeriod;
        }

        public double CalculateSuper(int grossIncome, int superRate)
        {
            double superRatePercentage = (double) superRate / 100;
            var super = grossIncome * superRatePercentage;
            return Math.Floor(super);
        }

        public int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            int netIncome = grossIncome - incomeTax;
            return netIncome;
        }
    }
}