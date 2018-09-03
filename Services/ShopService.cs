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
    public class ShopService : IShopService
    {
        public readonly ShopRepository shopRepository;

        public ShopService()
        {
            shopRepository = new ShopRepository();
        }

        public ShopM Delete(int id)
        {
            return shopRepository.Delete(id);
        }

        public ShopM Edit(ShopM shop)
        {
            return shopRepository.Edit(shop);
        }

        public IEnumerable<ShopM> FindAll()
        {
            return shopRepository.FindAll();
        }

        public ShopM FindById(int id)
        {
            return shopRepository.FindById(id);
        }

        public ShopM Save(ShopM shop)
        {
            return shopRepository.Save(shop);
        }
    }
}
