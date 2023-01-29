using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class PayzeePaymentResponseModelResult
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string orderId { get; set; }
        public object txnType { get; set; }
        public string txnStatus { get; set; }
        public int vposId { get; set; }
        public string vposName { get; set; }
        public string authCode { get; set; }
        public object hostReference { get; set; }
        public string totalAmount { get; set; }
    }

    public class PayzeePaymentResponseModel
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public PayzeePaymentResponseModelResult result { get; set; }
    }
}
