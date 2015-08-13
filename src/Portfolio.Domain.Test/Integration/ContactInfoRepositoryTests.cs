using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Integration
{
    [TestClass]
    public class ContactInfoRepositoryTests
    {
        private ProfileRepository profileRepository = new ProfileRepository();
        private ContactInfoRepository contactInfoRepository = new ContactInfoRepository();
        private readonly string profileReference = "michaelquinn5280@gmail.com";

        [TestMethod]
        public void CreateNewContactInfo()
        {
            var profileId = profileRepository.FindProfileId(profileReference);
            contactInfoRepository.DeleteContactInfo(profileId);
            var contactInfo = new ContactInfo
            {
                Id = string.Empty,
                ProfileId = profileId,
                ContactMessage = "If you have any interesting technical challenges and/or unique business opportunities I would love to hear about them.",
                ContactInstructions = "This form is just saving off to a DB right now, if you want to contact me please use the email link below.",
                EmailAddress = "michaelquinn5280@gmail.com",
                City = "Irvine",
                State = "CA",
                Zip = "92604"
            };
            contactInfoRepository.SaveContactInfo(contactInfo);
            var results = contactInfoRepository.GetContactInfo(profileId);
            Assert.AreEqual(profileId, results.ProfileId);
        }
    }
}
