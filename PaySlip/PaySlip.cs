using System;

namespace PaySlip.Kata
{
    public class PaySlip
    {
        private readonly PersonDetails _personDetails;
        private string FullName { get; }
        private string PaymentPeriod { get; }
        private int GrossIncome { get; }
        private double IncomeTax { get; }
        private int NetIncome { get; }
        private double Super { get; }

        public PaySlip(PersonDetails personDetails)
        {
            _personDetails = personDetails;
        }

        public PaySlipResult PaySlipCalculator()
        {
            var fullName = _personDetails.GetFullName();
            var paymentPeriod = _personDetails.GeneratePaymentPeriod();
            var grossIncome = CalculateGrossIncome(_personDetails.AnnualSalary);

            var tax = new IncomeTaxCalculator(_personDetails.AnnualSalary);
            tax.TaxRateInfoLoader();
            var incomeTax = tax.CalculateIncomeTax();
            var netIncome = CalculateNetIncome(grossIncome, (int) incomeTax);
            var super = CalculateSuper(grossIncome, _personDetails.SuperRate);

            return new PaySlipResult(fullName, paymentPeriod, grossIncome,
                incomeTax,
                netIncome, super);
        }

        public int CalculateGrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;
            return grossIncome;
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

//        public void printPaySlip()
    }
}