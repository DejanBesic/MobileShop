using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShopRepository : IDisposable
    {
        IEnumerable<ShopM> FindAll();
        ShopM FindById(int id);
        ShopM Save(ShopM shop);
        ShopM Delete(int id);
        ShopM Edit(ShopM shop);
    }
}
