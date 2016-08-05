using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using TestApp.Models.Api;

namespace TestApp.Services.Teams
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamModel>> GetAll();
        Task<HttpResponseMessage> Create(TeamModel model);
        Task<HttpResponseMessage> Delete(TeamModel model);
        Task<TeamModel> GetByID(TeamModel model);
        Task<TeamModel> Update(TeamModel model);
        Task<TeamModel> AddMember(TeamModel model);
        Task<HttpResponseMessage> RequestJoin(TeamModel model);
    }
}
