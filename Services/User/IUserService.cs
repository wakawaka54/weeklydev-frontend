using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using TestApp.Models;
using TestApp.Models.Api.User;

namespace TestApp.Services.User
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(LoginUserModel user);
        Task<HttpResponseMessage> Logout();
        Task<HttpResponseMessage> Register(NewUserModel user);
        Task<UserModel> Me();
        Task<HttpResponseMessage> ChangePassword(PasswordChangeUserModel user);
    }
}
