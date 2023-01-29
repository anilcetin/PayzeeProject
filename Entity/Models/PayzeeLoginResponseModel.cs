using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Result
    {
        public int userId { get; set; }
        public string token { get; set; }
    }

    public class PayzeeLoginResponseModel
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public Result result { get; set; }
        public int count { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
    }
}
