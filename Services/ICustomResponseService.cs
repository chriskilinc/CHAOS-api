using ChaosApi.Controllers;
using ChaosApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaosApi.Utils
{
    public interface ICustomResponseService
    {
        BaseResponse CreateBaseResponse(CreateBaseResponsePayload payload, HttpContext context);
        PingResponse CreatePingResponse(CreatePingResponsePayload payload, HttpContext context);
        CommandsResponse CreateCommandsResponse(CreateCommandsResponsePayload payload, HttpContext context);
        CryptoListingResponse CreateCryptoListingResponse(CreateCryptoListingResponsePayload payload, HttpContext context);
    }
}
