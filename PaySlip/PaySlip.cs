using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip.Kata
{
    public class PaySlip
    {
        private string FullName { get; }
        private string PaymentPeriod { get; }
        private int GrossIncome { get; }
        private double IncomeTax { get; }
        private int NetIncome { get; }
        private double Super { get; }

        public PaySlip(string fullName, string paymentPeriod, int grossIncome, double incomeTax, int netIncome,
            double super)
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