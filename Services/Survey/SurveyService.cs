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
    public class SurveyService : ISurveyService
    {
        IApiService apiService;
        HttpContext context;

        public SurveyService(IApiService _apiService,
            IHttpContextAccessor _accessor)
        {
            apiService = _apiService;
            context = _accessor.HttpContext;
        }

        public async Task<HttpResponseMessage> GetSurvey(SurveyModel model)
        {
            var response = await apiService.Get("survey");
            string tempString = await response.Content.ReadAsStringAsync();

            model = JsonConvert.DeserializeObject<SurveyModel>(await response.Content.ReadAsStringAsync());

            return response;
        }

        public Task<HttpResponseMessage> SetSurvey(SurveyModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return apiService.Post("survey", content);
        }
    }
}
