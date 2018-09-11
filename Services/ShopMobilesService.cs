using IServices;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShopMobilesService : IShopMobilesService
    {
        private readonly ShopMobilesRepository shopMobilesRepository;

        public ShopMobilesService()
        {
            shopMobilesRepository = new ShopMobilesRepository();
        }

        public ShopMobilesM Delete(int id)
        {
            return shopMobilesRepository.Delete(id);
        }

        public ShopMobilesM Edit(ShopMobilesM shopMobiles)
        {
            return shopMobilesRepository.Edit(shopMobiles);
        }

        public IEnumerable<ShopMobilesM> FindAll()
        {
            return shopMobilesRepository.FindAll();
        }

        public ShopMobilesM FindById(int id)
        {
            return shopMobilesRepository.FindById(id);
        }

        public ShopMobilesM FindByShopAndMobile(int shopId, int mobileId)
        {
            return shopMobilesRepository.FindByShopAndMobile(shopId, mobileId);
        }

        public ShopMobilesM Save(ShopMobilesM shopMobiles)
        {
            return shopMobilesRepository.Save(shopMobiles);
        }
    }
}
