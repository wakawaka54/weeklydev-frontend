using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestApp.Models;

namespace TestApp.Services.User
{
    interface IUserService
    {
        bool Login(ApplicationUser user);
        ApplicationUser GetUser(string jwt);
        bool Logout();
    }
}
