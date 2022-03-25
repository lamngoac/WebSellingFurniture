using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) : base(projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
