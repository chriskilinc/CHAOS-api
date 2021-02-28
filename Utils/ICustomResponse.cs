using ChaosApi.Controllers;
using ChaosApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaosApi.Utils
{
    public interface ICustomResponse
    {
        BaseResponse CreateResponse(ResponsePayload payload, HttpContext context);
    }
}
