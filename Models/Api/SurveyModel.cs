using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestApp.Models.Api
{
    public class SurveyModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        public string[] Role { get; set; }

        [JsonProperty("project_manager")]
        public bool ProjectManager { get; set; }

        [JsonProperty("skill_level")]
        [Range(3, 5)]
        public int SkillLevel { get; set; }

        [JsonProperty("project_size")]
        public int ProjectSize { get; set; }

        public int Timezone { get; set; }

        public SurveyModel()
        {
            //TODO - NEEDS TO BE FIXED IN API TO START WITH GOOD DEFAULTS
            //Set defaults
            Role = new string[] { "manager", "frontend", "backend" };
            ProjectSize = 3;
            SkillLevel = 3;
            ProjectManager = true;
            Timezone = 0;
        }
    }
}
