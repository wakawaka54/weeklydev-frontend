using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public class ApiService : IApiService
    {
        public Task<string> Get(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task Post(string endpoint, string json)
        {
            throw new NotImplementedException();
        }
    }
}