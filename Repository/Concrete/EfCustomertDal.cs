using Entity.Models;
using Repository.Abstract;
using Repository.CoreRepo;

namespace Repository.Concrete
{
    public class EfCustomertDal : EfEntityRepositoryBase<Customer, PayzeeProjectContext>, ICustomerDal
    { 
    }
}
