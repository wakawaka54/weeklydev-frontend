using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using TestApp.Models;

namespace TestApp.Services.User
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(UserModel user);
        Task<HttpResponseMessage> Logout();
        Task<HttpResponseMessage> Register(UserModel user);
        Task<UserModel> Me();
    }
}
