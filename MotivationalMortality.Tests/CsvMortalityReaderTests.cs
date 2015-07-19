using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalMortality.Tests
{
    [TestFixture]
    public class CsvMortalityReaderTests
    {
        [Test]
        public void CsvReader_WhenLoadingProfiles_WithCsvFile_ReturnsProfiles()
        {
            CsvMortalityProfileRepo repo = new CsvMortalityProfileRepo("MortalityProfiles.csv");
            IList<MortalityProfile> profiles = repo.GetProfiles();

            Assert.IsNotNull(profiles);
            CollectionAssert.AllItemsAreNotNull(profiles);
        }
    }
}
