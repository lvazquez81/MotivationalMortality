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
    public class MortalityReportTests
    {
        [Test]
        public void MortalityReport_WhenProvidingDate_ReturnsAgeAndWeeks()
        {
            DateTime myBirthday = new DateTime(1981, 04, 29);
            Mock<ITimeProvider> myTime = new Mock<ITimeProvider>();
            myTime.Setup(x => x.GetCurrentDate()).Returns(new DateTime(2015, 04, 29));

            MortalityReporter reporter = new MortalityReporter(myTime.Object, "MortalityProfiles.csv");
            LifeReport report = reporter.GetLifeReport("Luis Vazquez", "Mexico", true, myBirthday);

            Assert.IsNotNull(report);
            Assert.IsFalse(string.IsNullOrWhiteSpace(report.Name));
            Assert.AreEqual("Luis Vazquez", report.Name);
            Assert.IsTrue(report.WeeksLived > 0);
            Assert.IsTrue(report.YearsLived > 0);
            Assert.AreEqual(34, report.YearsLived);
            
        }
    }
}
