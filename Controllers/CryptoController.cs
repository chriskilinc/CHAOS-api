using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;
using ChaosApi.Models;
using ChaosApi.Models.Response.Crypto;
using ChaosApi.Utils;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChaosApi.Controllers
{
    [ApiController]
    [Route("api/crypto")]
    public class CryptoController : Controller
    {
        private ICustomResponseService CustomResponseService;
        public CryptoController(ICustomResponseService customResponseService)
        {
            CustomResponseService = customResponseService;
        }

        // TODO: Chart
        // https://api.coingecko.com/api/v3/coins/bitcoin/market_chart?vs_currency=eur&days=3&interval=daily

        [HttpGet]
        [Route("listing/{symbol}/{fiat?}")]
        public async Task<JsonResult> GetPrice(string symbol, string fiat = "eur")
        {
            var result = await Fetch("quotes/latest", symbol, fiat);
            var response = CreateCryptoResponse(result);
            response.method = "api/crypto/listing";

            return new JsonResult(response);
        }

        public CryptoResponse CreateCryptoResponse(CMCResponse CMCResponse)
        {
            CryptoResponse response = new CryptoResponse();
            if (CMCResponse != null)
            {
                response.successful = true;
                response.message = $"Listing for {CMCResponse.Data.BTC.Name}";
                response.data = new CryptoData()
                {
                    lastUpdated = CMCResponse.Data.BTC.Quote.EUR.LastUpdated,
                    name = CMCResponse.Data.BTC.Name,
                    price = CMCResponse.Data.BTC.Quote.EUR.Price,
                    raw = CMCResponse,
                    symbol = CMCResponse.Data.BTC.Symbol,
                };
            }
            else
            {
                response.successful = false;
                response.message = "Could not get listing.";
            }
            return response;
        }

        public async Task<CMCResponse> Fetch(string endpoint, string symbol, string fiat)
        {
            var api = "https://pro-api.coinmarketcap.com/v1/cryptocurrency";

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = symbol;
            queryString["convert"] = fiat;

            var url = $"{api}/{endpoint}?{queryString}"; // "https://www.pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol=btc&convert=eur"
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("X-CMC_PRO_API_KEY", "7c001994-3cf3-47da-b74d-ef8e4692d7ed");

            CMCResponse result = new CMCResponse();
            using (var httpClient = new HttpClient())
            {
                using (var httpResponse = await httpClient.SendAsync(request))
                {
                    try
                    {
                        string response = await httpResponse.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<CMCResponse>(response);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }

            return result;
        }
    }

    public class CMCResponse
    {
        public CMCStatus Status { get; set; }
        public CMCData Data { get; set; }

    }

    public class CMCStatus
    {
        public DateTime Timestamp { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        public string Elapsed { get; set; }
        [JsonProperty("credit_count")]
        public int CreditCount { get; set; }
    }

    public class CMCData
    {
        public CMCCoin BTC { get; set; }
    }

    public class CMCCoin
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public CMCQuote Quote { get; set; }
    }

    public class CMCQuote
    {
        public CMCQuoteFiat EUR { get; set; }
    }

    public class CMCQuoteFiat
    {
        public string Price { get; set; }
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("percent_change_1h")]
        public string ChangeHour { get; set; }
        [JsonProperty("percent_change_24h")]
        public string ChangeDay { get; set; }
        [JsonProperty("percent_change_7d")]
        public string ChangeWeek { get; set; }
        [JsonProperty("percent_change_30d")]
        public string ChangeMonth { get; set; }
    }

}