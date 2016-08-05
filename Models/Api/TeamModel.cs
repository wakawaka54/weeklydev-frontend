using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TestApp.Models.Api
{
    public class TeamModel
    {
        [JsonProperty("role")]
        public IEnumerable<RoleModel> Roles { get; set; }
    }

    public class RoleModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        public string Role { get; set; }
    }
}
