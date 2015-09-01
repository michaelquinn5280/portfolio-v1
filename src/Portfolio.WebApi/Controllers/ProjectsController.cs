using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Portfolio.Domain;
using Portfolio.Domain.Entities;

namespace Portfolio.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<Project>))]
        [Route("api/projects/{profileId}")]
        public IHttpActionResult Get(Guid? profileId)
        {
            if (profileId == null || !profileId.HasValue)
                return BadRequest();
            var repository = new ProjectRepository();
            var projects = repository.GetProjects(profileId.Value).OrderBy(p=>p.Priority).ToList();
            return Ok(projects);
        }
    }
}
