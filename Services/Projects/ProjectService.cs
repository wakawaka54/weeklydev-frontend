using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestApp.Models.Api;

using Newtonsoft.Json;

namespace TestApp.Services.Projects
{
    public class ProjectService : ApiServiceBase, IProjectService
    {
        public ProjectService(IApiService _api)
            :base(_api)
        {

        }

        public Task<HttpResponseMessage> Create(ProjectModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return apiService.Post("projects", content);
        }

        public async Task<IEnumerable<ProjectModel>> GetAll()
        {
            var projects = new List<ProjectModel>();
            var response = await apiService.Get("projects");

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                projects = JsonConvert.DeserializeObject<List<ProjectModel>>(await response.Content.ReadAsStringAsync());
            }

            return projects;
        }

        public async Task<ProjectModel> GetByID(ProjectModel model)
        {
            var project = new ProjectModel();
            var response = await apiService.Get("projects/" + model.ID);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                project = JsonConvert.DeserializeObject<ProjectModel>(await response.Content.ReadAsStringAsync());
            }

            return project;
        }
    }
}
