using System;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;

namespace Portfolio.Domain
{
    public class SiteInfoRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public SiteInfo GetSiteInfo(Guid profileId)
        {
            var siteInfo = _dataContext.Single<SiteInfo>(g => g.ProfileId.Equals(profileId));
            return siteInfo;
        }

        public void SaveSiteInfo(SiteInfo siteInfo)
        {
            _dataContext.Save(siteInfo);
        }

        public void DeleteSiteInfo(Guid profileId)
        {
            _dataContext.Delete<SiteInfo>(c => c.ProfileId == profileId);
        }
    }
}
