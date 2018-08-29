using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICustomerService : IService
    {
        IEnumerable<CustomerM> FindAll();
        CustomerM FindById(int id);
        CustomerM FindByEmail(string email);
        CustomerM Delete(int id);
        CustomerM Edit(CustomerM customer);
        CustomerM Save(CustomerM customer);
    }
}
