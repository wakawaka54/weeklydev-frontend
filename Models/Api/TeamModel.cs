using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TestApp.Models.Api
{  
    public class TeamModel
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        public UserModel Frontend { get; set; }
        public UserModel Backend { get; set; }
        public UserModel Manager { get; set; }
    }
}
