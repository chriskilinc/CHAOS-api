using ChaosApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ChaosApi.Utils
{
    public class CryptoListingResponse : BaseResponse
    {
        static HttpClient client = new HttpClient();
        public string symbol { get; set; }
        public string fiat { get; set; }

        // TODO: Implement some kind of AutoMapper?
        public CryptoListingResponse(BaseResponse baseResponse, CreateCryptoListingResponsePayload payload)
        {
            message = baseResponse.message;
            method = baseResponse.method;
            symbol = payload.Symbol;
            fiat = payload.Fiat;

            try
            {
                var response = makeAPICall();
            }
            catch (WebException e)
            {
                throw new WebException("Failed to call CMC", e);
            }
        }

        public async Task<string> makeAPICall()
        {
            var endpoint = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest";
            
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = symbol;
            queryString["convert"] = fiat;

            var url = $"{endpoint}?{queryString}";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("X-CMC_PRO_API_KEY", "7c001994-3cf3-47da-b74d-ef8e4692d7ed");
            var task = client.SendAsync(request)
                .ContinueWith((taskwithmsg) =>
                {
                    var response = taskwithmsg.Result.Content;

                    //var jsonTask = response.Content.ReadAsAsync<JsonObject>();
                    //jsonTask.Wait();
                    //var jsonObject = jsonTask.Result;
                });
            task.Wait();

            // https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyQuotesLatest
            return "";
        }
    }
}
