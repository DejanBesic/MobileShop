using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly MobileShopEntities Context;

        public ShopRepository()
        {
            Context = new MobileShopEntities();
        }

        public ShopM Delete(int id)
        {
            Shop shop = Context.Shops.SingleOrDefault(x => x.Id == id);
            Context.Shops.Remove(shop);
            Context.SaveChanges();

            return new ShopM()
            {
                Id = shop.Id,
                ContactAddress = shop.ContactAddress,
                ContactMobilePhone = shop.ContactMobilePhone,
                ContactPhone = shop.ContactPhone,
                HirePayment = shop.HirePayment ?? false,
                OpenTime = shop.OpenTime,
                ShopName = shop.ShopName,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ShopM Edit(ShopM shop)
        {
            var found = Context.Shops.SingleOrDefault(x => x.Id == shop.Id);
            if (found == null)
            {
                return null;
            }
            found.ShopName = shop.ShopName;
            found.OpenTime = shop.OpenTime;
            found.ContactPhone = shop.ContactPhone;
            found.ContactMobilePhone = shop.ContactMobilePhone;
            found.ContactAddress = shop.ContactAddress;
            found.HirePayment = shop.HirePayment;
            Context.SaveChanges();

            return shop;
        }

        public IEnumerable<ShopM> FindAll()
        {
            List<ShopM> retVal = new List<ShopM>();
            foreach (Shop shop in Context.Shops.ToList())
            {
                retVal.Add(new ShopM()
                {
                    Id = shop.Id,
                    ContactAddress = shop.ContactAddress,
                    ContactMobilePhone = shop.ContactMobilePhone,
                    ContactPhone = shop.ContactPhone,
                    HirePayment = shop.HirePayment ?? false,
                    OpenTime = shop.OpenTime,
                    ShopName = shop.ShopName,
                });
            }

            return retVal;
        }

        public ShopM FindById(int id)
        {
            Shop shop = Context.Shops.SingleOrDefault(x => x.Id == id);

            return new ShopM()
            {
                Id = shop.Id,
                ContactAddress = shop.ContactAddress,
                ContactMobilePhone = shop.ContactMobilePhone,
                ContactPhone = shop.ContactPhone,
                HirePayment = shop.HirePayment ?? false,
                OpenTime = shop.OpenTime,
                ShopName = shop.ShopName,
            };
        }

        public ShopM Save(ShopM shop)
        {
            Shop shopDb = new Shop()
            {
                ContactAddress = shop.ContactAddress,
                ContactMobilePhone = shop.ContactMobilePhone,
                ContactPhone = shop.ContactPhone,
                HirePayment = shop.HirePayment,
                OpenTime = shop.OpenTime,
                ShopName = shop.ShopName,
            };
            Context.Shops.Add(shopDb);
            Context.SaveChanges();
            shop.Id = shopDb.Id;
            return shop;
        }
    }
}
