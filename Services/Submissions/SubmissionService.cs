using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using TestApp.Models.Api;

namespace TestApp.Services.Submissions
{
    public class SubmissionService : ApiServiceBase, ISubmissionService
    {
        public SubmissionService(IApiService _api)
            :base(_api)
        {

        }
    }
}
