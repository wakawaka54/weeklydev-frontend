using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using TestApp.Models.Api;
using TestApp.Models.Api.Teams;

namespace TestApp.Services.Teams
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamModel>> GetAll();
        Task<HttpResponseMessage> Create(NewTeamModel model);
        Task<HttpResponseMessage> Delete(TeamModel model);
        Task<TeamModel> GetByID(TeamModel model);
        Task<TeamModel> Update(TeamModel model);
        Task<TeamModel> AddMember(TeamModel model);
        Task<HttpResponseMessage> RequestJoin(RequestJoinTeamModel model);
    }
}
