using Entity.Models;
using IdentityServiceReference;
using Repository.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async void Add(Customer customer)
        {
            customer.IdentityNoVerified = true;
            customer.Status = true;

            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            await client.OpenAsync();

            var result = await client.TCKimlikNoDogrulaAsync(customer.IdentityNo, customer.Name, customer.Surname, customer.BirthDate);
            if (result.Body.TCKimlikNoDogrulaResult)
            {
                var verifyCustomer = new Customer
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    BirthDate= customer.BirthDate,
                    IdentityNo = customer.IdentityNo,
                    IdentityNoVerified = false,
                    Status = true
                };
                _customerDal.Add(verifyCustomer);
            }
            else
            {
                throw new Exception("Girilen müşteri bilgileri doğrulanamadı");
            }
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();

        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
