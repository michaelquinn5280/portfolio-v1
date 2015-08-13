using System;
using System.Web.Http;
using Portfolio.Domain;
using Portfolio.Domain.Entities;
using System.Web.Http.Description;

namespace Portfolio.WebApi.Controllers
{
    public class SiteInfoController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(SiteInfo))]
        [Route("api/siteinfo/{profileId}")]
        public IHttpActionResult GetSiteInfo(Guid? profileId)
        {
            //todo: use data annotations of fluent validators
            if (profileId == null || !profileId.HasValue)
                return BadRequest();
            var repository = new SiteInfoRepository();
            var response = repository.GetSiteInfo(profileId.Value);
            return Ok(response);
        }
    }
}
