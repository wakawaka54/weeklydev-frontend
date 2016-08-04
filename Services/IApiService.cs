using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace TestApp.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> Post(string endpoint, StringContent content, Action<HttpRequestHeaders> headers = null);
        Task<HttpResponseMessage> Get(string endpoint, Action<HttpRequestHeaders> headers = null);
    }
}
