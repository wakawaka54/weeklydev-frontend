using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Api.User
{
    public class NewUserSuccessModel
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}
