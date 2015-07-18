using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality
{
    internal class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
