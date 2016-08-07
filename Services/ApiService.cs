using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

using TestApp.Services.Authentication;
using System.Net.Http.Headers;

namespace TestApp.Services
{
    public class ApiService : IApiService
    {
        string defaultBasePath = "http://104.236.48.115:1337/v1/";

        ILogger<ApiService> _logger;
        IApiAuth _authentication;

        public ApiService(ILogger<ApiService> logger,
            IApiAuth auth)
        {
            _logger = logger;
            _authentication = auth;
        }

        public async Task<HttpResponseMessage> Post(string endpoint, StringContent content, Action<HttpRequestHeaders> headers = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(defaultBasePath);
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, endpoint);

                headers?.Invoke(message.Headers);

                _authentication.ApplyAuthentication(message);

                message.Content = content;

                response = await client.SendAsync(message);
            }

            return response;
        }

        public async Task<HttpResponseMessage> Get(string endpoint, Action<HttpRequestHeaders> headers = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(defaultBasePath);
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, endpoint);

                headers?.Invoke(message.Headers);

                _authentication.ApplyAuthentication(message);

                response = await client.SendAsync(message);
            }

            return response;
        }

        public async Task<HttpResponseMessage> Delete(string endpoint, Action<HttpRequestHeaders> headers = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(defaultBasePath);
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, endpoint);

                headers?.Invoke(message.Headers);

                _authentication.ApplyAuthentication(message);

                response = await client.SendAsync(message);
            }

            return response;
        }
    }
}