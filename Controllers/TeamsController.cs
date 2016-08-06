using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult New()
        {
            return View(new NewTeamModel());
        }

        [HttpPost]
        public async Task<IActionResult> New(NewTeamModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await teamService.Create(model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("All");
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