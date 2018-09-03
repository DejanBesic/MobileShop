using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShoppingRepository : IDisposable
    {
        IEnumerable<ShoppingM> FindAll();
        ShoppingM FindById(int id);
        ShoppingM Save(ShoppingM shopping);
        ShoppingM Delete(int id);
        ShoppingM Edit(ShoppingM shopping);
    }
}
