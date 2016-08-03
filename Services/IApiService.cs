using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public interface IApiService
    {
        Task Post(string endpoint, string json);
        Task<string> Get(string endpoint);
    }
}
