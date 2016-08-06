using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Api.User
{
    public class ConfirmUserModel
    {
        public bool Confirmed { get; set; }
        public string ErrorMessage { get; set; }
    }
}
