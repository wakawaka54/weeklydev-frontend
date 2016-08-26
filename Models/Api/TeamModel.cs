using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TestApp.Models.Api
{  
    public class TeamModel
    {
        [JsonProperty(PropertyName = "_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }
        public UserModel Manager { get; set; }
        public string Name { get; set; }
        public ProjectModel Project { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
    }
}
