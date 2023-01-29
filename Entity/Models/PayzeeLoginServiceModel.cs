using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class PayzeeLoginServiceModel : IEntity
    {
        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
    }
}
