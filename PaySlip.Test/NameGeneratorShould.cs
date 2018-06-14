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
            var personName = new PersonDetails(firstName, lastName);
//            personName.setFullName(firstName, lastName);
            var expectedFullName = personName.getFullName();

            Assert.Equal(expectedFullName, actualFullName);
        }
    }
}