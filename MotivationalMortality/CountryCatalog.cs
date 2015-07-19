using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality
{
    public static class CountryCatalog
    {
        public static List<string> GetCountryList()
        {
            return new List<string>()
            {
                "Mexico",
                "Japan",
                "United States of America",
                "France",
                "Brazil"
            };
        }
    }
}
