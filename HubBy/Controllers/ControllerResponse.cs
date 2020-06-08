using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Controllers
{
    /// <summary>
    /// The APIs controller responses
    /// </summary>
    public struct ControllerResponse
    {
        public string Message { get; set; }

        public ControllerResponse(string Message)
        {
            this.Message = Message;
        }
    }
}
