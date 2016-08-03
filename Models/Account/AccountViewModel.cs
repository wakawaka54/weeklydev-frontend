using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class AccountViewModel
    {
        public string Username { get; set; }
        public string Password {get; set; }
        public string Email {get; set;}
        public bool RememberMe {get; set;}
    }
}
