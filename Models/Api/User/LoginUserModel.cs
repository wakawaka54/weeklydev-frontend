using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestApp.Models.Api.User
{
    public class LoginUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public bool RememberMe { get; set; }
    }
}
