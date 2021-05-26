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
                StatusCode = 200,
                Message = "Ping Successful",
                Method = "ping",
                Data = new PingData() { ping = true }
            }, HttpContext);

            return new JsonResult(pingResponse);
        }

        [HttpGet]
        [Route("commands")]
        public IActionResult GetCommands()
        {
            CommandsResponse commansResponse = CustomResponseService.CreateCommandsResponse(new CreateCommandsResponsePayload()
            {
                Data = new CommandsData()
                {
                    Commands = new List<Command>()
                    {
                        new Command { Route = "api/ping", Method = "GET", Description = "Ping the Api" },
                        new Command { Route = "api/commands", Method = "GET", Description = "Returns a list of available commands" },
                    }
                },
                Message = "List of available commands",
                Method = "commands",
                StatusCode = 200
            }, HttpContext);
            return new JsonResult(commansResponse);
        }
    }
}