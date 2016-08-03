using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace TestApp.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> Post(string endpoint, string json);
        Task<string> Get(string endpoint);
    }
}
