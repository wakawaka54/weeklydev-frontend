using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TestApp.Models.Api
{  
    public class TeamModel
    {
        public UserModel Frontend { get; set; }
        public UserModel Backend { get; set; }
        public UserModel Manager { get; set; }
    }
}
