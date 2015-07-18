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
        
        public MortalityReporter(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
        
        public LifeReport GetLifeReport(string name, DateTime myBirthday)
        {
            LifeWeekCalculator calc = new LifeWeekCalculator(_timeProvider);

            return new LifeReport()
            {
                Name = name,
                WeeksLived = calc.GetWeeksFromLife(myBirthday),
                YearsLived = calc.GetYearsFromLife(myBirthday)
            };
        }
    }
}
