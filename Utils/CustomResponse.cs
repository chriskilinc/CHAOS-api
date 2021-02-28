using ChaosApi.Controllers;
using ChaosApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaosApi.Utils
{
    public class CustomResponse : ICustomResponse
    {
        public BaseResponse CreateResponse(ResponsePayload payload, HttpContext context)
        {
            context.Response.StatusCode = payload.StatusCode;
            var response = new BaseResponse()
            {
                message = payload.Message,
                method = payload.Method
            };
            return response;
        }
    }

    public class ResponsePayload
    {
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}
