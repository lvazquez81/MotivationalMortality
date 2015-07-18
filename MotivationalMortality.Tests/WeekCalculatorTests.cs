using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality.Tests
{
    [TestFixture]
    public class WeekCalculatorTests
    {
        [Test]
        public void WeekCalculator_WhenCalculatingWeeks_WithPastDate_ReturnsWeekNumber()
        {
            DateTime myBirthday = new DateTime(1981, 04, 29);
            Mock<ITimeProvider> myTime = new Mock<ITimeProvider>();
            myTime.Setup(x => x.GetCurrentDate()).Returns(new DateTime(2015, 04, 29));

            LifeWeekCalculator calc = new LifeWeekCalculator(myTime.Object);
            int weeks = calc.GetWeeksFromLife(myBirthday);

            Assert.IsTrue(weeks > 0);
        }

        [Test]
        public void WeekCalculator_WhenCalculatingYears_WithPastDate_ReturnsWeekNumber()
        {
            DateTime myBirthday = new DateTime(1981, 04, 29);
            Mock<ITimeProvider> myTime = new Mock<ITimeProvider>();
            myTime.Setup(x => x.GetCurrentDate()).Returns(new DateTime(2015, 04, 29));

            LifeWeekCalculator calc = new LifeWeekCalculator(myTime.Object);
            int years = calc.GetYearsFromLife(myBirthday);

            Assert.IsTrue(years > 0);
            Assert.AreEqual(34, years);
        }
    }
}
