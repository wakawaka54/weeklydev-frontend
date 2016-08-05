using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TestApp.Models;
using TestApp.Models.Api;
using TestApp.Services.Survey;
using Newtonsoft.Json;

namespace TestApp.Controllers
{
    public class SurveyController : Controller
    {
        private SurveyModel surveyModel;
        private ISurveyService survey;

        public SurveyController(ISurveyService _survey)
        {
            survey = _survey;
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        [Route("survey/")]
        public async Task<IActionResult> Survey()
        {
            surveyModel = await survey.GetSurvey();
            if(surveyModel != null)
            {
                return View(surveyModel);
            }
            else
            {
                surveyModel = new SurveyModel();
                return View(surveyModel);
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("survey/")]
        public async Task<IActionResult> Survey(SurveyModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var response = await survey.SetSurvey(model);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return LocalRedirect("/");
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
    }
}
