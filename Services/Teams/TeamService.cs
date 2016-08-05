using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using TestApp.Models.Api;

namespace TestApp.Services.Teams
{
    public class TeamService : ApiServiceBase, ITeamService
    {
        public TeamService(IApiService _api)
            :base(_api)
        {

        }

        public Task<TeamModel> AddMember(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Create(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Delete(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TeamModel> GetByID(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> RequestJoin(TeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TeamModel> Update(TeamModel model)
        {
            throw new NotImplementedException();
        }
    }
}
