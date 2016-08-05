using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class UserModel
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password {get; set; }
        public string Email {get; set;}

        [JsonIgnore]
        public bool RememberMe {get; set;}
    }
}
