using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.DataContext;

namespace Portfolio.Domain
{
    public class ProjectRepository
    {
        private readonly IDataContext _dataContext = new MongoContext();

        public Project GetProject(Guid profileId)
        {
            var project = _dataContext.Single<Project>(p => p.ProfileId.Equals(profileId));
            return project;
        }

        public IQueryable<Project> GetProjects(Guid profileId)
        {
            var projects = _dataContext.All<Project>();
            return projects;
        }

        public void SaveProject(Project project)
        {
            _dataContext.Save(project);
        }

        public void SaveProjects(List<Project> projects)
        {
            _dataContext.Save(projects);
        }

        public void DeleteProjects(Guid profileId)
        {
            _dataContext.Delete<Project>(c => c.ProfileId == profileId);
        }
    }
}
