namespace ChaosApi.Utils
{
    public class CreateCryptoListingResponsePayload : CreateBaseResponsePayload
    {
        public string Symbol { get; set; }
        public string Fiat { get; set; }
    }
}
