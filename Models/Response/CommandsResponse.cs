using ChaosApi.Models;
using System.Collections.Generic;

namespace ChaosApi.Utils
{
    public class CommandsResponse : BaseResponse
    {
        public CommandsData data { get; set; }

        // TODO: Implement some kind of AutoMapper?
        public CommandsResponse(BaseResponse baseResponse, CreateCommandsResponsePayload payload)
        {
            message = baseResponse.message;
            method = baseResponse.method;
            data = payload.Data;
        }
    }

    public class CommandsData
    {
        public List<string> Commands { get; set; }
    }
}
