using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        void Add(Customer customer);

        void Update(Customer customer);
    }
}
