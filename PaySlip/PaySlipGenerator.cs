using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        public void GeneratePaySlip()
        {
            var formQuestionsFile = @"./files/formQuestions.json";
            var paySlipFormFile = @"./files/paySlip.json";

            var personDetails = GeneratePersonDetails(GetPersonDetails(formQuestionsFile));
            //returns payslip?
        }

        public void Foo()
        {
//            var fullName = _personDetails.GetFullName();
//            var paymentPeriod = _personDetails.GeneratePaymentPeriod();
//            var grossIncome = CalculateGrossIncome(_personDetails.AnnualSalary);
//
//            var tax = new IncomeTaxCalculator(_personDetails.AnnualSalary);
//            tax.TaxRateInfoLoader();
//            var incomeTax = tax.CalculateIncomeTax();
//            var netIncome = CalculateNetIncome(grossIncome, (int) incomeTax);
//            var super = CalculateSuper(grossIncome, _personDetails.SuperRate);
//
//            return new PaySlipResult(fullName, paymentPeriod, grossIncome,
//                incomeTax,
//                netIncome, super);
        }

        private Dictionary<string, string> GetPersonDetails(string formQuestionsFile)
        {
            var userDetails = new Dictionary<string, string>();

            using (StreamReader file = new StreamReader(formQuestionsFile))
            {
                var json = file.ReadToEnd();
                var formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                foreach (var field in formFields)
                {
                    Console.Write(field.Value);
                    userDetails.Add(field.Key, Console.ReadLine());
                }
            }

            return userDetails;
        }

        private PersonDetails GeneratePersonDetails(Dictionary<string, string> userDetails)
        {
            return new PersonDetails(userDetails["firstName"], userDetails["lastName"],
                Convert.ToInt32(userDetails["annualSalary"]),
                Convert.ToInt32(userDetails["superRate"]), userDetails["paymentStartDate"],
                userDetails["paymentEndDate"]);
        }
    }
}