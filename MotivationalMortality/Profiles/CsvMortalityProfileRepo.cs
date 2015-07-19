using CsvHelper;
using MotivationalMortality.Profiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MotivationalMortality
{
    public class CsvMortalityProfileRepo : IMortalityProfileRepository
    {
        private readonly IList<MortalityProfile> _profiles;

        private const string HEADER_COUNTRY_AND_YEAR = "Country; Year";
        private const string HEADER_AGE_AVERAGE = "Life expectancy at birth (years); Both sexes";
        private const string HEADER_AGE_MALE_AVERAGE = "Life expectancy at birth (years); Male";
        private const string HEADER_AGE_FEMALE_AVERAGE = "Life expectancy at birth (years); Female";

        public CsvMortalityProfileRepo(string csvFilename)
        {
            if (string.IsNullOrWhiteSpace(csvFilename))
                throw new FileNotFoundException("Did not provide csv filename: " + csvFilename);

            if (!File.Exists(csvFilename))
                throw new FileNotFoundException("Csv file not found in: " + csvFilename);

            _profiles = readAllCsvData(csvFilename);
        }

        public IList<MortalityProfile> GetAllProfiles()
        {
            var results = from x in _profiles
                          where x.StatisticYear == 2013
                          select x;

            return results.ToList<MortalityProfile>();
        }

        private IList<MortalityProfile> readAllCsvData(string csvFilename)
        {
            TextReader csvText = File.OpenText(csvFilename);
            var csv = new CsvReader(csvText);
            csv.Configuration.HasHeaderRecord = true;
            List<MortalityProfile> data = new List<MortalityProfile>();
            while (csv.Read())
            {
                data.Add(new MortalityProfile()
                {
                    StatisticYear = GetYearField(csv, HEADER_COUNTRY_AND_YEAR),
                    CountryName = GetCountryField(csv, HEADER_COUNTRY_AND_YEAR),
                    AverageAge = csv.GetField<int>(HEADER_AGE_AVERAGE),
                    AverageMaleAge = csv.GetField<int>(HEADER_AGE_MALE_AVERAGE),
                    AverageFemaleAge = csv.GetField<int>(HEADER_AGE_FEMALE_AVERAGE)

                });
            }
            return data;
        }

        private string GetCountryField(CsvReader reader, string countryHeaderName)
        {
            string csvCountryValue = reader.GetField<string>(countryHeaderName);
            int indexOfDelimiter = csvCountryValue.IndexOf(";");
            return csvCountryValue.Substring(0, indexOfDelimiter);
        }

        private int GetYearField(CsvReader reader, string countryHeaderName)
        {
            string csvCountryValue = reader.GetField<string>(countryHeaderName);
            int indexOfDelimiter = csvCountryValue.IndexOf(";");
            string yearValue = csvCountryValue.Substring(indexOfDelimiter + 1, csvCountryValue.Length - indexOfDelimiter - 1);
            return Convert.ToInt32(yearValue.Trim());
        }

        public MortalityProfile GetProfileByCountry(string country)
        {
            return (from x in _profiles
                   where x.CountryName.Equals(country)
                   select x).FirstOrDefault();
        }
    }
}
