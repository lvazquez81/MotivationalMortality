using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality
{
    public class MortalityProfile
    {
        public int StatisticYear { get; set; }
        public string CountryName { get; set; }
        public int AverageFemaleAge { get; set; }
        public int AverageMaleAge { get; set; }
        public int AverageAge { get; set; }

    }
}
