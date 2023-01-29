using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public bool Status { get; set; }
    }
}
