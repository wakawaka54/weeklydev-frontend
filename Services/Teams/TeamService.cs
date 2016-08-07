using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Newtonsoft.Json;

using TestApp.Models.Api;
using TestApp.Models.Api.Teams;

namespace TestApp.Services.Teams
{
    public class TeamService : ApiServiceBase, ITeamService
    {
        HttpContext context;

        public TeamService(IApiService _api, IHttpContextAccessor accessor)
            :base(_api)
        {
			context = accessor.HttpContext;
        }

        public Task<TeamModel> AddMember(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Create(NewTeamModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return apiService.Post("teams", content);
        }

        public Task<HttpResponseMessage> Delete(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeamModel>> GetAll()
        {
            var teams = new List<TeamModel>();
            var response = await apiService.Get("teams");
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                teams = JsonConvert.DeserializeObject<List<TeamModel>>(json);
            }

            return teams;
        }

        public Task<TeamModel> GetByID(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> RequestJoin(RequestJoinTeamModel model)
        {
            string endpoint = ApiEndpoints.TeamJoinRequest("test");
            return null;
        }

        public Task<TeamModel> Update(TeamModel model)
        {
            throw new NotImplementedException();
        }
    }
}
