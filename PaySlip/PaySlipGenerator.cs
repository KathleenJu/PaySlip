using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        public void GeneratePaySlip()
        {
            var paySlipForm = new PaySlipForm();
            var personDetails = paySlipForm.GeneratePaySlipForm(); //refactor, not clear that its returning a persondetails class

            var paySlipManager = new PaySlipManager();
            var paySlipResult = paySlipManager.PaySlipCalculator(personDetails);
            ReturnPaySlipResult(paySlipResult);
        }

        private void ReturnPaySlipResult(PaySlipResult paySlip)
        {
            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine("Name: " + paySlip.FullName);
            Console.WriteLine("Pay Period: " + paySlip.PaymentPeriod);
            Console.WriteLine("Gross Income " + paySlip.GrossIncome);
            Console.WriteLine("Income Tax: " + paySlip.IncomeTax);
            Console.WriteLine("Net Income: " + paySlip.NetIncome);
            Console.WriteLine("Super: " + paySlip.Super);

            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}