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
        public const string PasswordChange = "users/me/password";
        public const string UserRecover = "users/passwordreset";
        public static Func<string, string> UserConfirm = (id) => { return $"users/confirm/{id}"; };
        public static Func<string, string> UserDelete = (id) => { return $"users/{id}"; };

        public const string Teams = "teams";
        public static Func<string, string> TeamJoinRequest = (id) => { return $"teams/{id}/join"; };
    }
}
