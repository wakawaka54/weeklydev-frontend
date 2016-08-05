using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using TestApp.Models.Api;
using Newtonsoft.Json;

namespace TestApp.Services.Survey
{
    public class SurveyService : ApiServiceBase, ISurveyService
    {
        HttpContext context;

        public SurveyService(IApiService _apiService,
            IHttpContextAccessor _accessor)
            :base(_apiService)
        {
            context = _accessor.HttpContext;
        }

        public async Task<SurveyModel> GetSurvey()
        {
            var response = await apiService.Get("survey");

            var model = JsonConvert.DeserializeObject<SurveyModel>(await response.Content.ReadAsStringAsync());

            return model;
        }

        public async Task<HttpResponseMessage> SetSurvey(SurveyModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return await apiService.Post("survey", content);
        }
    }
}
