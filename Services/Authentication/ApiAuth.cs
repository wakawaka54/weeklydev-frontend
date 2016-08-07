using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TestApp.Services.Authentication
{
    public class ApiAuth : IApiAuth
    {
        HttpContext context;

        public ApiAuth(IHttpContextAccessor accessor)
        {
            context = accessor.HttpContext;
        }

        public void ApplyAuthentication(HttpRequestMessage message)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", context.User.FindFirstValue(ClaimTypes.UserData));
            }
        }
    }
}
