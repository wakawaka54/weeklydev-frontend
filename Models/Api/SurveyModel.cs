using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestApp.Models.Api
{
    public class SurveyModel
    {
        public string[] Role { get; set; }

        [JsonProperty("project_manager")]
        public bool ProjectManager { get; set; }

        [JsonProperty("skill_level")]
        public int SkillLevel { get; set; }

        [JsonProperty("project_size")]
        public int ProjectSize { get; set; }

        public int Timezone { get; set; }
    }
}
