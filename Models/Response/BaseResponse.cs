namespace ChaosApi.Models
{
    public class BaseResponse
    {
        public string message { get; set; }
        public string method { get; set; }
        public bool successful { get; set; }
    }
}
