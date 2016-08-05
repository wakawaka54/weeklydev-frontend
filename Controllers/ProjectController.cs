using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TestApp.Services.Projects;
using TestApp.Models.Api;

namespace TestApp.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService projectService;

        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var projects = await projectService.GetAll();

            return View(projects);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View(new ProjectModel());
        }

        [HttpPost]
        public async Task<IActionResult> New(ProjectModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await projectService.Create(model);
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