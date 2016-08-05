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


        public DateTime Deadline { get; set; } = DateTime.Now.AddDays(14);
    }
}
