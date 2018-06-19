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


        public void PrintPaySlip(string paySlipFormFile)
        {
            using (StreamReader file = new StreamReader(paySlipFormFile))
            {
                var json = file.ReadToEnd();
                var formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                Console.WriteLine("\nYour payslip has been generated:\n");
                Console.WriteLine(formFields["FullName"] + FullName);
                Console.WriteLine(formFields["PaymentPeriod"] + PaymentPeriod);
                Console.WriteLine(formFields["GrossIncome"] + GrossIncome);
                Console.WriteLine(formFields["IncomeTax"] + IncomeTax);
                Console.WriteLine(formFields["NetIncome"] + NetIncome);
                Console.WriteLine(formFields["Super"] + Super);
                Console.WriteLine("\nThank you for using MYOB!");
            }
        }
    }
}