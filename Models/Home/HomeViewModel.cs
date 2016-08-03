using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestApp.Models.Home
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class HomeViewModel
    {
        public ApplicationUser User { get _session }

        private ISession _session => httpContextAccessor.HttpContext.Session;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeViewModel(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
    }
}
