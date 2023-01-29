using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var model = new VposRequest();
            model.OrderId = "anilTestOrder1";
            model.UserCode = "test";
            model.CustomerId = "1234";
            model.TotalAmount = "100";
            model.Rnd = "1994";
            model.TxnType = "Auth";

            Console.WriteLine(CreateHash(model));
        }

        public static string CreateHash(VposRequest request)
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
