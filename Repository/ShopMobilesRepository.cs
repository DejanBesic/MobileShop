using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShopMobilesRepository : IShopMobilesRepository
    {
        private readonly MobileShopEntities Context;


        public ShopMobilesRepository()
        {
            Context = new MobileShopEntities();
        }

        public ShopMobilesM Delete(int id)
        {
            Shop_Mobiles shopMobiles = Context.Shop_Mobiles.SingleOrDefault(x => x.Id == id);
            Context.Shop_Mobiles.Remove(shopMobiles);
            Context.SaveChanges();

            return new ShopMobilesM()
            {
                Id = shopMobiles.Id,
                MobileId = shopMobiles.MobileId ?? -1,
                MobilesLeft = shopMobiles.MobilesLeft ?? 0,
                ShopId = shopMobiles.ShopId ?? -1,
                Price = shopMobiles.Price ?? 0,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ShopMobilesM Edit(ShopMobilesM shopMobiles)
        {
            var found = Context.Shop_Mobiles.SingleOrDefault(x => x.Id == shopMobiles.Id);
            if (found == null)
            {
                return null;
            }
            found.ShopId = shopMobiles.ShopId;
            found.MobilesLeft = shopMobiles.MobilesLeft;
            found.MobileId = shopMobiles.MobileId;
            found.Price = shopMobiles.Price;
            Context.SaveChanges();

            return shopMobiles;
        }

        public IEnumerable<ShopMobilesM> FindAll()
        {
            List<ShopMobilesM> retVal = new List<ShopMobilesM>();
            foreach (Shop_Mobiles shopMobiles in Context.Shop_Mobiles.ToList())
            {
                retVal.Add(new ShopMobilesM()
                {
                    Id = shopMobiles.Id,
                    MobileId = shopMobiles.MobileId ?? -1,
                    MobilesLeft = shopMobiles.MobilesLeft ?? 0,
                    ShopId = shopMobiles.ShopId ?? -1,
                    Price = shopMobiles.Price ?? 0,
                });
            }

            return retVal;
        }

        public ShopMobilesM FindById(int id)
        {
            Shop_Mobiles shopMobiles = Context.Shop_Mobiles.SingleOrDefault(x => x.Id == id);

            return new ShopMobilesM()
            {
                Id = shopMobiles.Id,
                MobileId = shopMobiles.MobileId ?? -1,
                MobilesLeft = shopMobiles.MobilesLeft ?? 0,
                ShopId = shopMobiles.ShopId ?? -1,
                Price = shopMobiles.Price ?? 0,
            };
        }

        public ShopMobilesM Save(ShopMobilesM shopMobiles)
        {
            Shop_Mobiles shopMobilesDb = new Shop_Mobiles()
            {
                MobileId = shopMobiles.MobileId,
                MobilesLeft = shopMobiles.MobilesLeft,
                ShopId = shopMobiles.ShopId,
                Price = shopMobiles.Price,
            };
            Context.Shop_Mobiles.Add(shopMobilesDb);
            Context.SaveChanges();
            shopMobiles.Id = shopMobilesDb.Id;
            return shopMobiles;
        }

        public ShopMobilesM FindByShopAndMobile(int shopId, int mobileId)
        {
            var found = Context.Shop_Mobiles.SingleOrDefault(x => x.ShopId == shopId && x.MobileId == mobileId);
            if (found == null)
            {
                return null;
            }

            return new ShopMobilesM()
            {
                Id = found.Id,
                MobileId = found.MobileId ?? -1,
                Price = found.Price ?? 0,
                MobilesLeft = found.MobilesLeft ?? 0,
                ShopId = found.ShopId ?? -1,
            };
        }
    }
}
