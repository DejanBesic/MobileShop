using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IRepository
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<CustomerM> FindAll();
        CustomerM FindById(int id);
        CustomerM Save(CustomerM customer);
        CustomerM Delete(int id);
        CustomerM Edit(CustomerM customer);
        CustomerM FindByEmail(string Email);
    }
}
