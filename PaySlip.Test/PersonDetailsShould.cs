using PaySlip.Kata;
using Xunit;

namespace PaySlip.Test
{
    public class NameGeneratorShould
    {
        [Theory]
        [InlineData("John", "Doe", "John Doe")]
        [InlineData("Peter", "Smith", "Peter Smith")]
        [InlineData("ben", "peterson", "Ben Peterson")]
        [InlineData("scarlett", "jensen", "Scarlett Jensen")]
        public void GenerateFullNameWith(string firstName, string lastName, string actualFullName)
        {
            var personDetails = new PersonDetails(firstName, lastName, 0, 0, "test", "test");
            var expectedFullName =  personDetails.GetFullName();

            Assert.Equal(expectedFullName, actualFullName);
        }

        [Theory]
        [InlineData("1 march", "31 march", "1 March – 31 March")]
        [InlineData("1 june", "31 june", "1 June – 31 June")]
        [InlineData("1 september", "31 september", "1 September – 31 September")]
        public void PayPeriodShouldBeGenerated(string paymentStart, string paymentEnd, string actualPaymentPeriod)
        {
            var personDetails = new PersonDetails("test", "test", 0, 0, paymentStart, paymentEnd);
            var expectedPaymentPeriod = personDetails.GeneratePaymentPeriod(paymentStart, paymentEnd);

            Assert.Equal(expectedPaymentPeriod, actualPaymentPeriod);
        }
    }
}