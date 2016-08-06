using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestApp.Models.Api.User
{
    public class PasswordChangeUserModel
    {
        [JsonProperty("passOld")]
        public string PasswordOld { get; set; }

        [JsonProperty("passNew")]
        public string PasswordNew { get; set; }
    }
}
