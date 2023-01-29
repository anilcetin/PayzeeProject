using Entity.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Repository.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace Service.Concrete
{
    public class TransactionManager : ITransactionService
    {
        public IConfiguration _configuration { get; }
        ICustomerService _customerService;
        private PayzeeService _payzeeService;
        ITransactionDal _transactionDal;
        IHashService _hashService;

        public TransactionManager(ICustomerService customerService, ITransactionDal transactionDal, IHashService hashService, IConfiguration configuration)
        {
            _customerService = customerService;
            _transactionDal = transactionDal;
            _configuration = configuration;
            _payzeeService = _configuration.GetSection("PayzeeServices").Get<PayzeeService>();
            _hashService = hashService;
        }
        public async void Add(Transaction transaction)
        {
            var customer = _customerService.GetAll().FirstOrDefault(x => x.CustomerId == transaction.CustomerId && x.Status == true && x.IdentityNoVerified == false);
            VposRequestHashModel model = new VposRequestHashModel()
            {
                OrderId = transaction.OrderId,
                UserCode = "test",
                CustomerId = customer.CustomerId.ToString(),
                TotalAmount = transaction.Amount,
                Rnd = "abcd",
                TxnType = transaction.TypeId,
            };

            var hashData = _hashService.CreateHash(model);

            var loginModel = new PayzeeLoginServiceModel
            {
                ApiKey = _payzeeService.ApiKey,
                Email = "murat.karayilan@dotto.com.tr",
                Lang = "TR"
            };

            var httpClient = HttpClientFactory.Create();


            string loginContent = JsonConvert.SerializeObject(loginModel);

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(_payzeeService.PayzeeLogin, new StringContent(loginContent, Encoding.UTF8, "application/json"));

            PayzeePaymentServiceModel payzeePaymentServiceModel = new PayzeePaymentServiceModel();

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var result = JsonConvert.DeserializeObject<PayzeeLoginResponseModel>(await content.ReadAsStringAsync());

                var stream = result.result.token;
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(stream) as JwtSecurityToken;

                payzeePaymentServiceModel.MemberId = token.Claims.First(claim => claim.Type == "MemberId").Value;
                payzeePaymentServiceModel.UserCode = token.Claims.First(claim => claim.Type == "UserId").Value;
                payzeePaymentServiceModel.MerchantId = token.Claims.First(claim => claim.Type == "MerchantId").Value;
                payzeePaymentServiceModel.TotalAmount = transaction.Amount;
                payzeePaymentServiceModel.TxnType = transaction.TypeId;
                payzeePaymentServiceModel.InstallmentCount = "1";
                payzeePaymentServiceModel.Md = model.Rnd;
                payzeePaymentServiceModel.Hash = hashData;
                payzeePaymentServiceModel.OrderId = transaction.OrderId;
                payzeePaymentServiceModel.CardNumber = transaction.CardNumber;
                payzeePaymentServiceModel.ExpiryDateMonth = transaction.ExpiryDateMonth;
                payzeePaymentServiceModel.ExpiryDateYear = transaction.ExpiryDateYear;
                payzeePaymentServiceModel.Cvv = transaction.Cvv;
                payzeePaymentServiceModel.Currency = "949";

                var httpPaymentClient = HttpClientFactory.Create();

                string payzeePaymentServiceModelContent = JsonConvert.SerializeObject(payzeePaymentServiceModel);

                httpPaymentClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.result.token);

                HttpResponseMessage httpPaymentResponseMessage = await httpPaymentClient.PostAsync(_payzeeService.PayzeePayment, new StringContent(payzeePaymentServiceModelContent, Encoding.UTF8, "application/json"));

                if (httpPaymentResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var paymentContent = httpPaymentResponseMessage.Content;
                    var paymentResult = JsonConvert.DeserializeObject<PayzeePaymentResponseModel>(await paymentContent.ReadAsStringAsync());

                    //Payment Sonucu db ye kaydedilir

                    //Transaction kaydı için hash data hatalı sorunu fixlenemedi.

                    transaction.ResponseCode = paymentResult.result.responseCode;
                    transaction.ResponseMessage = paymentResult.result.responseMessage;

                    _transactionDal.Add(transaction);
                }

            }
        }

        public List<Transaction> GetAll()
        {
            return _transactionDal.GetAll();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
