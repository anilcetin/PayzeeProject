using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class VposRequestHashModel
    {
        public string UserCode { get; set; }
        public string Rnd { get; set; }
        public string TxnType { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }

    }
}
