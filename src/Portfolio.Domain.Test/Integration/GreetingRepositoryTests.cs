using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Integration
{
    [TestClass]
    public class GreetingRepositoryTests
    {
        private ProfileRepository profileRepository = new ProfileRepository();
        private GreetingRepository greetingRepository = new GreetingRepository();
        private readonly string profileReference = "michaelquinn5280@gmail.com";

        [TestMethod]
        public void CreateNewGreeting()
        {
            var profileId = profileRepository.FindProfileId(profileReference);
            greetingRepository.DeleteGreeting(profileId);
            var greeting = new Greeting
            {
                Id = string.Empty,
                ProfileId = profileId,
                GreetingTitle = "Michael Quinn",
                GreetingMessage = "full stack software developer",
                SiteInfo = "Using this site to explore ASP.NET 5, Web API 2.2 in 4.6, Visual Studio 2015, AngularJs, MongoDB.  UI is a Bootstrap wrapper called Cvilized I found on the wrapbootstap.com marketplace. Git source.  Hosted in Azure."
            };
            greetingRepository.SaveGreeting(greeting);
            var results = greetingRepository.GetGreeting(profileId);
            Assert.AreEqual(greeting.ProfileId, results.ProfileId);
        }
    }
}
