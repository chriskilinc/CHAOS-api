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
            successful = true;
        }
    }

    public class CommandsData
    {
        public List<Command> Commands { get; set; }
    }

    public class Command
    {
        public string Route { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
    }

}
