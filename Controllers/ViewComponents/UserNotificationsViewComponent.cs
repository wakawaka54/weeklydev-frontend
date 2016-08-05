using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TestApp.Services.User;

namespace TestApp.Controllers.ViewComponents
{
    public class UserNotificationsViewComponent : ViewComponent
    {
        IUserService user;

        public UserNotificationsViewComponent(IUserService _user)
        {
            user = _user;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userModel = await user.Me();

            //Server issues, log user out just to be safe
            if(userModel == null) { await user.Logout(); return View(new Models.UserModel()); }

            return View(userModel);
        }
    }
}
