using System;
using System.Collections.Generic;

namespace PaySlip.Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the payslip generator! \n\n");
            
            var paySlipGenerator = new PaySlipGenerator();
            var paySlip = paySlipGenerator.GeneratePaySlip();
            
//            var payslip = paySlipGenerator.GeneratePaySlip(personalDetails);  
//            payslip.PrintPaySlip();
           
        }
    }
}
