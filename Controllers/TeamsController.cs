using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using TestApp.Services.Teams;
using TestApp.Models.Api;
using TestApp.Models.Api.Teams;

namespace TestApp.Controllers
{
    public class TeamsController : Controller
    {
        ITeamService teamService;

        public TeamsController(ITeamService _teamService)
        {
            teamService = _teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Join(string id = null)
        {
            if(id == null) { return await All(); }
            return await All();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var tests = await teamService.GetAll();

            return View(tests);
        }

        [HttpGet]
        public IActionResult New(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            return View(new NewTeamModel());
        }

        [HttpPost]
        public async Task<IActionResult> New(NewTeamModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                model = new NewTeamModel();
                model.Roles = new List<RoleModel>()
                {
                    new RoleModel() { ID =  HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid), Role = "frontend" }
                };

                var response = await teamService.Create(model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if(returnUrl == null) { returnUrl = "All"; }
                    return RedirectToAction(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
                    return View(model);
                }
            }

            return View(model);
        }
    }
}