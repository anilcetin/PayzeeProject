using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class PayzeePaymentServiceModel
    {
        public string MerchantId { get; set; }
        public string MemberId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }
        public string UserCode { get; set; }
        public string TxnType { get; set; }
        public string InstallmentCount { get; set; }
        public string Currency { get; set; }
        public string OrderId { get; set; }
        public string TotalAmount { get; set; }
        public string Md { get; set; }
        public string Hash { get; set; }
    }
}
