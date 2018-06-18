using System;

namespace PaySlip.Kata
{
    public class PaySlipManager
    {
        private readonly PersonDetails _personDetails;
        //taxRateInfo json file
        
        public PaySlipManager(PersonDetails personDetails)
        {
            _personDetails = personDetails;
        }
        public PaySlipResult PaySlipCalculator()
        {
            var fullName = _personDetails.GetFullName();
            var paymentPeriod = _personDetails.GeneratePaymentPeriod(_personDetails.PaymentStartDate, _personDetails.PaymentEndDate);
            var grossIncome = CalculateGrossIncome(_personDetails.AnnualSalary);

            var taxRateInfo = "files/taxRateInfo.json";
            var tax = new IncomeTaxCalculator(_personDetails.AnnualSalary, taxRateInfo);
            var incomeTax = tax.CalculateIncomeTax();
            var netIncome =  CalculateNetIncome(grossIncome, (int) incomeTax);
            var super =  CalculateSuper(grossIncome, _personDetails.SuperRate);

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
    }
}