using System;
using System.Web.Http;
using Portfolio.WebApi.Models;
using Portfolio.Domain;
using System.Web.Http.Description;

namespace Portfolio.WebApi.Controllers
{
    public class LegalController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(Copyright))]
        [Route("api/copyright/{profileId}")]
        public IHttpActionResult Get(Guid? profileId)
        {
            if (profileId == null || !profileId.HasValue)
                return BadRequest(); 
            var repository = new ProfileRepository();
            var response = repository.GetProfile(profileId.Value);
            return Ok(new Copyright { CompanyName = response.Name, CopyrightStartYear = 2015, CopyrightEndYear = DateTime.Now.Year });
        }
    }
}