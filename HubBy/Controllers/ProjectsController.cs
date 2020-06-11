using HubBy.Database.Models;
using HubBy.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<List<Project>> Get() =>
            _projectService.Get();

        [HttpPost]
        public IActionResult PostJson([FromBody] Project project)
        {
            var result = _projectService.Create(project);

            if (result == null)
                return (Json(new ControllerResponse("An error occured")));
            return (Json(new ControllerResponse("Ok")));
        }

        /// <summary>
        /// This endpoint is only made to delete internal projects
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] dynamic options)
        {
            try
            {
                if (String.IsNullOrEmpty(options.ProjectName.Value))
                    return (Json(new ControllerResponse("No ProjectName provided")));
                if (_projectService.Remove(options.ProjectName.Value))
                {
                    return (Json(new ControllerResponse("Ok")));
                }
                else
                {
                    return (Json(new ControllerResponse("Couldn't delete entry, no matching ProjectName ?")));
                }

            }
            catch (Exception)
            {
                return (Json(new ControllerResponse("A backend error occured, please contact the administrators.")));
            }
        }
    }
}
