using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace TestApp.Services.Authentication
{
    public interface IApiAuth
    {
        void ApplyAuthentication(HttpClient client);
    }
}
