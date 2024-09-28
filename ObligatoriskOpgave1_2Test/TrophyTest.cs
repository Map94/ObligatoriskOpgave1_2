using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave1_2;
namespace ObligatoriskOpgave1_2Test
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy Trophy = new Trophy();

        [TestMethod()]
        public void StringSportIsNull_ThrowException()
        {
            Trophy.Sport = null;

            Assert.ThrowsException<ArgumentNullException>(() => Trophy.validateSport());
        }


        [TestMethod()]
        public void StringSportLenghtIsOutOfRange_ThrowException()
        {
            Trophy.Sport = "meh";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateSport());
        }


        [TestMethod()]
        public void IntYearIsOutOfUpperRange_ThrowException()
        {
            Trophy.Year = 2069;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateYear());
        }


        [TestMethod()]
        public void IntYearIsOutOfLowerRange_ThrowException()
        {
            Trophy.Year = 1859;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateYear());
        }
    }
}