using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using TestApp.Models;
using TestApp.Models.Api.User;
using TestApp.Services.User;
using TestApp.Models.Infrastructure;

namespace TestApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService user;

        public AccountController(IUserService _user)
        {      
            user = _user;
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginUserModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var response = await user.Login(model);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if(returnUrl == null) { returnUrl = "/dashboard"; }
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var response = await user.Logout();
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return LocalRedirect("/");
            }

            return LocalRedirect("/");
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new NewUserModel());
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NewUserModel model, string returnUrl = null)
        {
            var response = await user.Register(model);
            
            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return LocalRedirect("/Account/Login");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Error creating new user");
                ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var response = await user.Me();

            return View(response);
        }

        //
        // GET: /Account/PasswordChange
        [HttpGet]
        public IActionResult PasswordChange(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new PasswordChangeUserModel());
        }

        //
        // GET: /Account/Recover
        public IActionResult Recover()
        {
            return View(new RecoverUseModel());
        }

        [HttpPost]
        public async Task<IActionResult> Recover(RecoverUseModel model)
        {

            return LocalRedirect("/");
        }

        //
        // POST: /Account/PasswordChange
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordChange(PasswordChangeUserModel model, string returnUrl = null)
        {
            var response = await user.ChangePassword(model);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error changing passwords!");
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Confirm(string userid)
        {
            var response = await user.Confirm(userid);

            ConfirmUserModel model = new ConfirmUserModel() { Confirmed = response.StatusCode == System.Net.HttpStatusCode.OK };

            return View(model);
        }

        [HttpGet]
        [Route("/dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            UserModel model = await user.Me();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var response = await user.Delete();
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var message = new ApplicationMessage() { MessageType = ApplicationMessageType.Success, Message = "User deleted successfully!" };
                TempData["Message"] = JsonConvert.SerializeObject(message);
                return LocalRedirect("/");
            }
            else
            {
                var message = new ApplicationMessage() { MessageType = ApplicationMessageType.Danger, Message = "Error deleting user!" };
                TempData["Message"] = JsonConvert.SerializeObject(message);
                return Redirect(Request.Headers["Referer"].ToString()); 
            }            
        }
    }
}
