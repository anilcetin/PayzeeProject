using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Transaction : IEntity
    { 
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string OrderId { get; set; }
        public string TypeId { get; set; }
        public string Amount { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool Status { get; set; }
    }
}
