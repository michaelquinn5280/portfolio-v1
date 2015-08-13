using System;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;

namespace Portfolio.Domain
{
    public class ContactInfoRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public ContactInfo GetContactInfo(Guid profileId)
        {
            var contactInfo = _dataContext.Single<ContactInfo>(g => g.ProfileId.Equals(profileId));
            return contactInfo;
        }

        public void SaveContactInfo(ContactInfo contactInfo)
        {
            _dataContext.Save(contactInfo);
        }

        public void DeleteContactInfo(Guid profileId)
        {
            _dataContext.Delete<ContactInfo>(c => c.ProfileId == profileId);
        }
    }
}
