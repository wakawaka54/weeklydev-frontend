using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using TestApp.Models.Api;

namespace TestApp.Services.Survey
{
    public interface ISurveyService
    {
        Task<SurveyModel> GetSurvey();
        Task<HttpResponseMessage> SetSurvey(SurveyModel model);
    }
}
