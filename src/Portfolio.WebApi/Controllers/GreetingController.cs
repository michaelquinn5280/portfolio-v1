using System;
using System.Web.Http;
using System.Web.Http.Description;
using Portfolio.Domain;
using Portfolio.Domain.Entities;

namespace Portfolio.WebApi.Controllers
{
    public class GreetingController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(Greeting))]
        [Route("api/greeting/{profileId}")]
        public IHttpActionResult Get(Guid? profileId)
        {
            if (profileId == null || !profileId.HasValue)
                return BadRequest();
            var repository = new GreetingRepository();
            var response = repository.GetGreeting(profileId.Value);
            return Ok(response);
        }
    }
}
