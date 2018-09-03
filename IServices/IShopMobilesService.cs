using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IShopMobilesService : IService
    {
        IEnumerable<ShopMobilesM> FindAll();
        ShopMobilesM FindById(int id);
        ShopMobilesM Save(ShopMobilesM shopMobiles);
        ShopMobilesM Delete(int id);
        ShopMobilesM Edit(ShopMobilesM shopMobiles);
    }
}
