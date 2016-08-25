using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestApp.Models.Api
{
    public class ProjectModel
    {
        [JsonProperty(PropertyName = "_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public UserModel Creator { get; set; }
        public bool Public { get; set; }

        [JsonProperty(PropertyName = "created_on", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }
        public DateTime Deadline { get; set; }
        public string[] Tags { get; set; }
        public int Votes { get; set; }
        public string[] Upvotes { get; set; }
        public string[] Downvotes { get; set; }
    }
}
