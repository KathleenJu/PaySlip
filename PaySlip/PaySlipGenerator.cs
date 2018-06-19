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
        public PaySlip GeneratePaySlip()
        {
            var formQuestionsFile = @"./files/formQuestions.json";
            var paySlipFormFile = @"./files/paySlip.json";

            var personDetails = GeneratePersonDetails(GetPersonDetails(formQuestionsFile));
            return PaySlip(personDetails);
        }

        private PaySlip PaySlip(PersonDetails personDetails)
        {
            var fullName = personDetails.GetFullName();
            var paymentPeriod = personDetails.GeneratePaymentPeriod();
            var taxCalculator = new TaxCalculator(personDetails.AnnualSalary);
            var grossIncome = taxCalculator.CalculateGrossIncome(personDetails.AnnualSalary);
            taxCalculator.TaxRateInfoLoader();
            var incomeTax = taxCalculator.CalculateIncomeTax();
            var netIncome = taxCalculator.CalculateNetIncome(grossIncome, (int) incomeTax);
            var super = taxCalculator.CalculateSuper(grossIncome, personDetails.SuperRate);
            return new PaySlip(fullName, paymentPeriod, grossIncome,
                incomeTax,
                netIncome, super);
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
                Convert.ToInt32(userDetails["annualSalary"]), Convert.ToInt32(userDetails["superRate"]),
                userDetails["paymentStartDate"], userDetails["paymentEndDate"]);
        }

//        public void PrintPaySlip(string paySlipFormFile)
//        {
//            using (StreamReader file = new StreamReader(paySlipFormFile))
//            {
//                var json = file.ReadToEnd();
//                var formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
//
//                Console.WriteLine("\nYour payslip has been generated:\n");
//                Console.WriteLine(formFields["FullName"] + FullName);
//                Console.WriteLine(formFields["PaymentPeriod"] + PaymentPeriod);
//                Console.WriteLine(formFields["GrossIncome"] + GrossIncome);
//                Console.WriteLine(formFields["IncomeTax"] + IncomeTax);
//                Console.WriteLine(formFields["NetIncome"] + NetIncome);
//                Console.WriteLine(formFields["Super"] + Super);
//                Console.WriteLine("\nThank you for using MYOB!");
//            }
//        }
    }
}