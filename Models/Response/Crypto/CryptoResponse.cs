using ChaosApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaosApi.Models.Response.Crypto
{
    public class CryptoResponse : BaseResponse
    {
        public CryptoData data { get; set; }
    }

    public class CryptoData
    {
        public string price { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public DateTime lastUpdated { get; set; }
        public CMCResponse raw { get; set; }
    }
}
