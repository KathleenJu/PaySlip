using System;

namespace PaySlip.Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the payslip generator! \n");
            
            var payslip = new PaySlipGenerator();
            payslip.GeneratePaySlipForm();
        }
    }
}
