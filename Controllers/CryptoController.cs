using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ChaosApi.Models;
using ChaosApi.Utils;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("listing/{symbol}/{fiat?}")]
        public IActionResult GetLatestListing(string symbol, string fiat = "eur")
        {
            //CryptoListingResponse cryptoListingResponse = CustomResponseService.CreateCryptoListingResponse(new CreateCryptoListingResponsePayload()
            //{
            //    StatusCode = 200,
            //    Message = $"Successful listing for {symbol} by {fiat}",
            //    Method = "ping",
            //    Symbol = symbol,
            //    Fiat = fiat,
            //}, HttpContext);

            //CryptoListingResponse cryptoListingResponse = new CryptoListingResponse( new BaseResponse() { }, new CreateCryptoListingResponsePayload() { })
            //{
            //    fiat = fiat,
            //    message = $"Listing for {symbol} by {fiat}",
            //    symbol = symbol,
            //    method = "api/crypto/listing",
            //};

            //return new JsonResult(cryptoListingResponse);
            return new JsonResult(new CryptoResponse()
            {
                message = "Crypto Listing",
                method = "api/crypto/listing",
                fiat = fiat,
                symbol = symbol,
            });
        }
    }

    public class CryptoResponse : BaseResponse
    {
        public string symbol { get; set; }
        public string fiat { get; set; }
    }
}