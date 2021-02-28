using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ChaosApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChaosApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        private ICustomResponse CustomResponse;
        public ApiController(ICustomResponse customResponse)
        {
            CustomResponse = customResponse;
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Get()
        {
            var response = CustomResponse.CreateResponse(new ResponsePayload()
            {
                StatusCode = 418,
                Message = "Hello World",
                Method = "ping"
            }, HttpContext);

            return new JsonResult(response);
        }
    }
}