using Entity.Models;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class HashManager : IHashService
    {
        public HashManager()
        {

        }

        public string CreateHash(VposRequestHashModel request)
        {
            var apiKey = "kU8@iP3@"; // Bu bilgi size özel olup kayıtlı kullanıcınıza mail olarak gönderilmiştir.

            var hashString = $"{apiKey}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}";

            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create();

            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = System.BitConverter.ToString(bytes).Replace("-", "");

            return hash;
        }
    }
}
