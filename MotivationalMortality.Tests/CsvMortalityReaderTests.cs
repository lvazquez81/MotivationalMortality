using MotivationalMortality.Profiles;
using NUnit.Framework;
using System.Collections.Generic;

namespace MotivationalMortality.Tests
{
    [TestFixture]
    public class CsvMortalityReaderTests
    {
        [Test]
        public void CsvReader_WhenLoadingAllProfiles_WithCsvFile_ReturnsProfiles()
        {
            IMortalityProfileRepository repo = new CsvMortalityProfileRepo("MortalityProfiles.csv");
            IList<MortalityProfile> profiles = repo.GetAllProfiles();

            Assert.IsNotNull(profiles);
            CollectionAssert.AllItemsAreNotNull(profiles);
        }

        [Test]
        public void CsvReader_WhenLoadingProfile_WithCsvFile_ReturnsProfile()
        {
            string myCountry = "Mexico";
            
            IMortalityProfileRepository repo = new CsvMortalityProfileRepo("MortalityProfiles.csv");
            MortalityProfile myProfile = repo.GetProfileByCountry(myCountry);

            Assert.IsNotNull(myProfile);
            Assert.AreEqual(myCountry, myProfile.CountryName);
        }
    }
}
