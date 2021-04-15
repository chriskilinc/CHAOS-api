using ChaosApi.Controllers;
using ChaosApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaosApi.Utils
{
    public class CustomResponseService : ICustomResponseService
    {
        public BaseResponse CreateBaseResponse(CreateBaseResponsePayload payload, HttpContext context)
        {
            context.Response.StatusCode = payload.StatusCode;
            var response = new BaseResponse()
            {
                message = payload.Message,
                method = payload.Method
            };
            return response;
        }

        public PingResponse CreatePingResponse(CreatePingResponsePayload payload, HttpContext context)
        {
            PingResponse pingResponse = new PingResponse(CreateBaseResponse(payload, context), payload);
            return pingResponse;
        }

        public CommandsResponse CreateCommandsResponse(CreateCommandsResponsePayload payload, HttpContext context)
        {
            CommandsResponse commandsResponse = new CommandsResponse(CreateBaseResponse(payload, context), payload);
            return commandsResponse;
        }

        public CryptoListingResponse CreateCryptoListingResponse(CreateCryptoListingResponsePayload payload, HttpContext context)
        {
            CryptoListingResponse cryptoListingResponse = new CryptoListingResponse(CreateBaseResponse(payload, context), payload);
            return cryptoListingResponse;
        }
    }
}
