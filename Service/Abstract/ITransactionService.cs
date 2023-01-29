using Entity.Models;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface ITransactionService
    {
        List<Transaction> GetAll();

        void Add(Transaction transaction);

        void Update(Transaction transaction);
    }
}
