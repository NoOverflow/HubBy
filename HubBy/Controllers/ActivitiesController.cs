using HubBy.Database.Models;
using HubBy.Services;
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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteForm([FromForm] Dictionary<string, string> value)
        {
            string _id = null;
            string _name = null;
            DeleteResult result;

            if (!value.ContainsKey("Id") && !value.ContainsKey("Name"))
                return (BadRequest());
            value.TryGetValue("Id", out _id);
            value.TryGetValue("Name", out _name);
            result = (_id != null) ? _activityService.Remove(_id) : _activityService.RemoveName(_name);
            return (Json(new ControllerResponse(String.Format("Deleted {0} entries", result.DeletedCount)))); 
        }
    }
}
