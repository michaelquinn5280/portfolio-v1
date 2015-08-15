using System;
using System.Web.Http;
using Portfolio.Domain;
using Portfolio.Domain.Helpers;
using Portfolio.Domain.Entities;
using System.Web.Http.Description;
using System.Linq;
using System.Collections.Generic;

namespace Portfolio.WebApi.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(ContactInfo))]
        [Route("api/contactinfo/{profileId}")]
        public IHttpActionResult GetContactInfo(Guid? profileId)
        {
            //todo: use data annotations of fluent validators
            if (profileId == null || !profileId.HasValue)
                return BadRequest();
            var repository = new ContactInfoRepository();
            var response = repository.GetContactInfo(profileId.Value);
            return Ok(response);
        }

        [HttpGet]
        [ResponseType(typeof(List<ContactAttempt>))]
        [Route("api/contactattempt/{profileId}")]
        public IHttpActionResult GetContactAttempts(Guid? profileId)
        {
            if (profileId == null || !profileId.HasValue)
                return BadRequest(); 
            var repository = new ContactAttemptRepository();
            var response = repository.GetContactAttempts(profileId.Value);
            return Ok(response.ToList());
        }

        [HttpPost]
        [Route("api/contactattempt/{profileId}")]
        public IHttpActionResult Post(Guid? profileId, [FromBody]ContactAttempt contactAttempt)
        {
            if ((profileId == null || !profileId.HasValue) && contactAttempt != new ContactAttempt())
                return BadRequest();
            var repository = new ContactAttemptRepository();
            var response = repository.SaveContactAttempt(contactAttempt);
            if (MailHelper.SendMessage(contactAttempt) && response.Success)
                return Ok();
            return InternalServerError(new Exception("There was a issue submitting you request."));
        }
    }
}
