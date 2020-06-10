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

        [HttpDelete]
        public IActionResult DeleteForm(IEnumerable<string> value)
        {
            return (Json(new ControllerResponse("Ok")));
        }
    }
}
