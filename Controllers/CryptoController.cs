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
        public IActionResult getLatestListing(string symbol, string fiat = "eur")
        {
            CryptoListingResponse cryptoListingResponse = CustomResponseService.CreateCryptoListingResponse(new CreateCryptoListingResponsePayload()
            {
                StatusCode = 200,
                Message = $"Successful listing for {symbol} by {fiat}",
                Method = "ping",
                Symbol = symbol,
                Fiat = fiat,
            }, HttpContext);

            return new JsonResult(cryptoListingResponse);
        }
    }
}