using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICartService : IService
    {
        IEnumerable<CartM> FindAll();
        CartM FindById(int id);
        CartM Save(CartM cart);
        CartM Delete(int id);
        CartM Edit(CartM cart);
        IEnumerable<CartM> FindByCustomer(int id);
    }
}
