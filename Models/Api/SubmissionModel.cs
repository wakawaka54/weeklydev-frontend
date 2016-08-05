using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestApp.Models.Api
{
    public class SubmissionModel
    {
        public string Team { get; set; }
        public string Project { get; set; }

        [JsonProperty("repo_url")]
        public string RepoUrl { get; set; }
        public string Images { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
    }
}
