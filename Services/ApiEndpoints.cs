using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public class ApiEndpoints
    {
        public const string Login = "login";
        public const string Register = "users/new";
        public const string Logout = "logout";
        public const string UserMe = "users/me";
        public const string Teams = "teams";
        public static Func<string, string> TeamJoinRequest = (id) => { return "teams/" + id + "/join"; };
    }
}
