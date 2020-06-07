using HubBy.Database.Models;
using HubBy.Services;
using HubBy.Services.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : Controller
    {
        private readonly ActivityService _activityService;

        public ActivitiesController(ActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult<List<Activity>> Get() => _activityService.Get();

        [HttpPost]
        public IActionResult PostJson([FromBody] Activity activity)
        {
            _activityService.Create(activity);
            return (Json(new ControllerResponse("Ok")));
        }
    }
}
