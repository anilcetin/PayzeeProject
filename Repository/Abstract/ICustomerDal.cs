using Entity.Models;
using Repository.CoreRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstract
{
    public interface ICustomerDal : IEntitiyRepository<Customer>
    {
    }
}
