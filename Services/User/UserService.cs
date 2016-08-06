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
using TestApp.Models.Api.User;
using TestApp.Services.Email;
using Newtonsoft.Json;
using System.Security.Claims;

namespace TestApp.Services.User
{
    public class UserService : ApiServiceBase, IUserService
    {
        HttpContext context;
        IEmailService email;

        public UserService(IApiService _api, IEmailService _email, IHttpContextAccessor _accessor)
            :base(_api)
        {
            context = _accessor.HttpContext;
            email = _email;
        }

        public async Task<HttpResponseMessage> ChangePassword(PasswordChangeUserModel user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string json = await content.ReadAsStringAsync();

            var response = await apiService.Post(ApiEndpoints.PasswordChange, content);

            return response;
        }

        public async Task<HttpResponseMessage> Confirm(string userid)
        {
            string endpoint = ApiEndpoints.UserConfirm(userid);
            var response = await apiService.Get(endpoint);

            return response;
        }
        //S1It1cmY
        public async Task<HttpResponseMessage> Login(LoginUserModel user)
        {
            HttpResponseMessage response = await apiService.Post(ApiEndpoints.Login, null,
                x => { x.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username + ":" + user.Password))); });

            //Check if user was authenticated and then create Identity Claims to store into an Authentication Cookie
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var definition = new { Token = "", user = new UserModel() };
                var authToken = JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), definition);

                //Create claims and identity
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.UserData, authToken.Token));
                claims.Add(new Claim(ClaimTypes.Sid, authToken.user.ID));
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

        public async Task<UserModel> Me()
        {
            var response = await apiService.Get(ApiEndpoints.UserMe);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonUser = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(jsonUser);

                return user;
            }

            return null;
        }

        public async Task<HttpResponseMessage> Register(NewUserModel user)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(user));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await apiService.Post(ApiEndpoints.Register, content);

            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var json = await response.Content.ReadAsStringAsync();
                var userModel = JsonConvert.DeserializeObject<NewUserSuccessModel>(await response.Content.ReadAsStringAsync());
                var subject = "Welcome To WeeklyDev.io";
                var message = $"Confirm this email by visiting http:/localhost:{5000}/Account/Confirm?userid={userModel.User.UserID}";

                email.SendMail(userModel.User.Username, userModel.User.Email, subject, message);
            }

            return response;
        }
    }
}
