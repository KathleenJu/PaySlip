using System;

namespace PaySlip.Kata
{
    public class PaySlipResult
    {
        public string FullName { get; }
        public string PaymentPeriod { get; }
        public int GrossIncome { get; }
        public double IncomeTax { get; }
        public int NetIncome { get; }
        public double Super { get; }

        public PaySlipResult(string fullName, string paymentPeriod, int grossIncome,
            double incomeTax,
            int netIncome, double super)
        {
            FullName = fullName;
            PaymentPeriod = paymentPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
    }
}