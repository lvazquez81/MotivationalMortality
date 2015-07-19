using System;
using System.Collections.Generic;
namespace MotivationalMortality.Profiles
{
    public interface IMortalityProfileRepository
    {
        IList<MortalityProfile> GetAllProfiles();
        MortalityProfile GetProfileByCountry(string country);
    }
}
