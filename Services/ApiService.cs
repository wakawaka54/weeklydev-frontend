using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace TestApp.Services
{
    public class ApiService : IApiService
    {
        string defaultBasePath = "http://localhost:1337/v1/";

        ILogger<ApiService> _logger;

        public ApiService(ILogger<ApiService> logger)
        {
            _logger = logger;
        }

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
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, endpoint);
                StringContent content = new StringContent(json);
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/json");
                
                client.DefaultRequestHeaders.Clear();
                
                message.Content = content;

                response = await client.SendAsync(message);
            }

            return response;
        }
    }
}