using System;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;

namespace Portfolio.Domain
{
    public class ProfileRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public Guid FindProfileId(string reference)
        {
            var profileReference = _dataContext.Single<ProfileReference>(r => r.ReferenceValue.Equals(reference));
            return profileReference != null ? profileReference.ProfileId : new Guid();
        }

        public Guid GenerateNewProfileId(string reference)
        {
            Guid profileId = Guid.NewGuid();
            _dataContext.Save(new ProfileReference { Id = string.Empty, ReferenceValue = reference, ProfileId = profileId});
            return profileId;
        }

        public void SaveProfileReference(ProfileReference profileReference)
        {
            _dataContext.Save(profileReference);
        }

        public void DeleteProfileReference(Guid profileId)
        {
            _dataContext.Delete<ProfileReference>(c => c.ProfileId == profileId);
        }

        public Profile GetProfile(Guid profileId)
        {
            var profile = _dataContext.Single<Profile>(p => p.ProfileId.Equals(profileId));
            return profile;
        }

        public void SaveProfile(Profile profile)
        {
            _dataContext.Save(profile);
        }

        public void DeleteProfile(Guid profileId)
        {
            _dataContext.Delete<Profile>(c => c.ProfileId == profileId);
        }
    }
}
