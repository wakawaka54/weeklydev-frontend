using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestApp.Services
{
    public class ApiServiceBase
    {
        protected IApiService apiService;
        public ApiServiceBase(IApiService _apiService)
        {
            apiService = _apiService;
        }
    }
}
