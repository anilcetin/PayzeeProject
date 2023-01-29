using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class PayzeeService : IEntity
    {
        public string PayzeeLogin { get; set; }
        public string PayzeePayment { get; set; }
        public string ApiKey { get; set; }
    }
}
