using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality
{
    public class LifeWeekCalculator
    {
        private readonly ITimeProvider _timeProvider;
        public LifeWeekCalculator(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
        
        public int GetWeeksFromLife(DateTime myBirthday)
        {
            DateTime currentDate = _timeProvider.GetCurrentDate();
            double numbeOfWeeks = Math.Round((currentDate - myBirthday).TotalDays / 7, MidpointRounding.ToEven);
            return Convert.ToInt32(numbeOfWeeks);
        }

        public int GetYearsFromLife(DateTime myBirthday)
        {
            DateTime currentDate = _timeProvider.GetCurrentDate();
            TimeSpan years = currentDate - myBirthday;
            
            double numberOfYears = Math.Round(years.TotalDays / 365, MidpointRounding.ToEven);
            return Convert.ToInt32(numberOfYears);
        }
    }
}
