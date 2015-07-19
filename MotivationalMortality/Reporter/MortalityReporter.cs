using MotivationalMortality.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality
{
    public class MortalityReporter
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IMortalityProfileRepository _mortalityProfiles;
        
        public MortalityReporter(ITimeProvider timeProvider, string csvFilename)
        {
            _timeProvider = timeProvider;
            _mortalityProfiles = new CsvMortalityProfileRepo(csvFilename);
        }
        
        public LifeReport GetLifeReport(string name, string country, GenderType gender, DateTime myBirthday)
        {
            LifeWeekCalculator calc = new LifeWeekCalculator(_timeProvider);
            MortalityProfile expectancy = _mortalityProfiles.GetProfileByCountry(country);

            int expectedLifeExpectancyInYears = (gender == GenderType.Male) ? expectancy.AverageMaleAge : expectancy.AverageFemaleAge;

            return new LifeReport()
            {
                Name = name,
                WeeksLived = calc.GetWeeksFromLife(myBirthday),
                YearsLived = calc.GetYearsFromLife(myBirthday),
                ExpectedYears = expectedLifeExpectancyInYears,
                ExpectedWeeks = calculateWeeksForYears(expectedLifeExpectancyInYears)
            };
        }

        private int calculateWeeksForYears(int years)
        {
            return years * 12 * 4;
        }
    }
}
