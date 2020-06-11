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
            var result = _activityService.Create(activity);

            if (result == null)
                return (Json(new ControllerResponse("An error occured")));
            return (Json(new ControllerResponse("Ok")));
        }

        /// <summary>
        /// This endpoint is only made to delete internal activities, and not EPITECHs activities
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] dynamic options)
        {
            try
            {
                if (String.IsNullOrEmpty(options.Codeacti.Value))
                    return (Json(new ControllerResponse("No Codeacti provided")));
                if (_activityService.Delete(options.Codeacti.Value))
                {
                    return (Json(new ControllerResponse("Ok")));
                } 
                else
                {
                   return (Json(new ControllerResponse("Couldn't delete entry, no matching actId ?")));
                }
                
            }
            catch (Exception)
            {
                return (Json(new ControllerResponse("A backend error occured, please contact the administrators.")));
            }
        }
    }
}
