using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;

namespace TestApp.Services
{
    public class ApiService : IApiService
    {
        string defaultBasePath = "http://104.236.48.115:1337/v1/";

        public Task<string> Get(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, endpoint);
                client.SendAsync(message);
            }

            return null;
        }

        public async Task<HttpResponseMessage> Post(string endpoint, string json)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(defaultBasePath);
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, endpoint);
                message.Content = new StringContent(json);
                response = await client.SendAsync(message);
            }

            return response;
        }
    }
}