using System;
using System.Web.Http;
using System.Web.Http.Description;
using Portfolio.Domain;
using Portfolio.Domain.Entities;

namespace Portfolio.WebApi.Controllers
{
    public class ProfileController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(Profile))]
        [Route("api/profile/{profileId}")]
        public IHttpActionResult Get(Guid? profileId)
        {
            if (profileId == null || !profileId.HasValue)
                return BadRequest();
            var repository = new ProfileRepository();
            var response = repository.GetProfile(profileId.Value);
            return Ok(response);
        }
    }
}
