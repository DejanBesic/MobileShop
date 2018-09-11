using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShopMobilesRepository : IDisposable
    {
        IEnumerable<ShopMobilesM> FindAll();
        ShopMobilesM FindById(int id);
        ShopMobilesM Save(ShopMobilesM shopMobiles);
        ShopMobilesM Delete(int id);
        ShopMobilesM Edit(ShopMobilesM shopMobiles);
        ShopMobilesM FindByShopAndMobile(int shopId, int mobileId);
    }
}
