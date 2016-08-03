using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser
    {
        public UserModel User { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe {get; set;}

        public ApplicationUser()
        {
            User = new UserModel();
        }
    }
}
