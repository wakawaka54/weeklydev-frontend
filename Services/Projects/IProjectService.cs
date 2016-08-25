using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using TestApp.Models.Api;

namespace TestApp.Services.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectModel>> GetAll();
        Task<HttpResponseMessage> Create(ProjectModel model);
        Task<ProjectModel> GetByID(ProjectModel model);
        Task<HttpResponseMessage> Upvote(string projectId);
        Task<HttpResponseMessage> Downvote(string projectId);
    }
}
