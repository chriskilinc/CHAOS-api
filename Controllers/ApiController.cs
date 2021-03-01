using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ChaosApi.Models;
using ChaosApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChaosApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        private ICustomResponseService CustomResponseService;
        public ApiController(ICustomResponseService customResponseService)
        {
            CustomResponseService = customResponseService;
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            PingResponse pingResponse = CustomResponseService.CreatePingResponse(new CreatePingResponsePayload()
            {
                StatusCode = 418,
                Message = "Ping Successful",
                Method = "ping",
                Data = new PingData() { ping = true }
            }, HttpContext);

            return new JsonResult(pingResponse);
        }
    }
}