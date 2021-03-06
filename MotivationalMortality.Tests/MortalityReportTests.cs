﻿using Moq;
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
            string myCountry = "Mexico";
            DateTime myBirthday = new DateTime(1981, 04, 29);
            GenderType myGender = GenderType.Male;
            
            Mock<ITimeProvider> myTime = new Mock<ITimeProvider>();
            myTime.Setup(x => x.GetCurrentDate()).Returns(new DateTime(2015, 04, 29));

            MortalityReporter reporter = new MortalityReporter(myTime.Object, "MortalityProfiles.csv");
            LifeReport report = reporter.GetLifeReport(myBirthday, myGender, myCountry);

            Assert.IsNotNull(report);
            Assert.IsTrue(report.WeeksLived > 0);
            Assert.IsTrue(report.YearsLived > 0);
            Assert.AreEqual(34, report.YearsLived);
            
        }
    }
}
