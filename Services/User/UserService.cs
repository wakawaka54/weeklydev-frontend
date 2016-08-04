using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using TestApp.Models;
using Newtonsoft.Json;
using System.Security.Claims;

namespace TestApp.Services.User
{
    public class UserService : IUserService
    {
        IApiService apiService;
        HttpContext context;

        public UserService(IApiService _apiService,
            IHttpContextAccessor _accessor)
        {
            apiService = _apiService;
            context = _accessor.HttpContext;
        }

        public async Task<HttpResponseMessage> Login(UserModel user)
        {
            HttpResponseMessage response = await apiService.Post(ApiEndpoints.Login, null,
                x => { x.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username + ":" + user.Password))); });

            //Check if user was authenticated and then create Identity Claims to store into an Authentication Cookie
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var definition = new { Token = "" };
                var authToken = JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), definition);

                //Create claims and identity
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.UserData, authToken.Token));
                ClaimsIdentity identity = new ClaimsIdentity(claims, "WeeklyDevAPIAuthentication");
                //Create authentication cookie
                await context.Authentication.SignInAsync("WeeklyDevAPIAuthentication", new ClaimsPrincipal(identity));
            }

            return response;
        }

        public async Task<HttpResponseMessage> Logout()
        {
            await context.Authentication.SignOutAsync("WeeklyDevAPIAuthentication");
            return await apiService.Get(ApiEndpoints.Logout);
        }

        public Task<HttpResponseMessage> Register(UserModel user)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(user));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return apiService.Post("users/new", content);
        }
    }
}
