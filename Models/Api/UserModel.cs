using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestApp.Models.Api;

using Newtonsoft.Json;

namespace TestApp.Models
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        public string Username { get; set; }

        public string Email {get; set;}

        public SurveyModel Survey { get; set; }

        [JsonProperty("userId")]
        public string UserID { get; set; }

        public string[] Access { get; set; }

        public bool IsSearching { get; set; }

        public string Verified { get; set; }

        //TODO: Not populating with TeamModel, only getting shortid
        [JsonProperty("team")]
        public IEnumerable<TeamModel> Teams { get; set; }

        [JsonIgnore]
        public string Image
        {
            get
            {
                return "~/images/user/default.jpg";
            }

        }

        public int Notifications()
        {
            int notifications = 0;
            if(Survey == null) { notifications++; }
            if(Verified != "true") { notifications++; }

            return notifications;
        }
    }
}
