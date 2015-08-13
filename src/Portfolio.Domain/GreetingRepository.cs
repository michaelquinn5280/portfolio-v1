using System;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;

namespace Portfolio.Domain
{
    public class GreetingRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public Greeting GetGreeting(Guid profileId)
        {
            var greeting = _dataContext.Single<Greeting>(g => g.ProfileId.Equals(profileId));
            return greeting;
        }

        public void SaveGreeting(Greeting greeting)
        {
            _dataContext.Save(greeting);
        }

        public void DeleteGreeting(Guid profileId)
        {
            _dataContext.Delete<Greeting>(c => c.ProfileId == profileId);
        }
    }
}
