using System.Runtime.Intrinsics.X86;

namespace ConsoleApp
{
    public class VposRequest
    {
        public string UserCode { get; set; }
        public string Rnd { get; set; }
        public string TxnType { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }

    }
}