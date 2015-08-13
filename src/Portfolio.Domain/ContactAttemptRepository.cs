using System;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Domain
{
    public class ContactAttemptRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public IQueryable<ContactAttempt> GetContactAttempts(Guid profileId)
        {
            var contactAttempts = _dataContext.All<ContactAttempt>();
            return contactAttempts;
        }

        public Result SaveContactAttempt(ContactAttempt contactAttempt)
        {
            try
            {
                _dataContext.Save(contactAttempt);
                return new Result { Success = true };
            }
            catch (Exception ex)
            {
                //todo: log
                return new Result { Success = false, Message = ex.Message };
            }
        }
    }
}
