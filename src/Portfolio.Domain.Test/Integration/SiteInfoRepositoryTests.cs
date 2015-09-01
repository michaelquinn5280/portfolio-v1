using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Integration
{
    [TestClass]
    public class SiteInfoRepositoryTests
    {
        private ProfileRepository profileRepository = new ProfileRepository();
        private SiteInfoRepository siteInfoRepository = new SiteInfoRepository();
        private readonly string profileReference = "michaelquinn5280@gmail.com";

        [TestMethod]
        public void CreateNewSiteInfo()
        {
            var profileId = profileRepository.FindProfileId(profileReference);
            siteInfoRepository.DeleteSiteInfo(profileId);
            var siteInfo = new SiteInfo
            {
                Id = string.Empty,
                ProfileId = profileId,
                Theme = "blue",
                Title = "Michael Quinn - .NET Developer Irvine, CA",
                Description = "Michael Quinn - .NET Developer Irvine, CA"
            };
            siteInfoRepository.SaveSiteInfo(siteInfo);
            var results = siteInfoRepository.GetSiteInfo(profileId);
            Assert.AreEqual(profileId, results.ProfileId);
        }
    }
}
