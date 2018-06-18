using System.Globalization;

namespace PaySlip.Kata
{
    public class PersonDetails
    {
        private string FirstName { get; }
        private string LastName { get; }
        public int AnnualSalary { get; }
        public int SuperRate { get; }
        private string PaymentStartDate { get; }
        private string PaymentEndDate { get; }

        public PersonDetails(string firstName, string lastName, int annualSalary, int superRate,
            string paymentStartDate, string paymentEndDate)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
        }

        public string GetFullName()
        {
            var fullName = ToCapitalise(FirstName) + " " + ToCapitalise(LastName);
            return fullName;
        }

        public string GeneratePaymentPeriod()
        {
            var paymentPeriod = ToCapitalise(PaymentStartDate) + " – " + ToCapitalise(PaymentEndDate);
            return paymentPeriod;
        }

        private string ToCapitalise(string name)
        {
            var titleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name);
            return titleCase;
        }
    }
}