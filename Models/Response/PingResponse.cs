using ChaosApi.Models;

namespace ChaosApi.Utils
{
    public class PingResponse : BaseResponse
    {
        public PingData data { get; set; }

        // TODO: Implement some kind of AutoMapper?
        public PingResponse(BaseResponse baseResponse, CreatePingResponsePayload payload)
        {
            message = baseResponse.message;
            method = baseResponse.method;
            data = payload.Data;
        }
    }

    public class PingData
    {
        public bool ping { get; set; }
    }
}
