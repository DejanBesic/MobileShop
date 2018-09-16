using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly MobileShopEntities Context;

        public ShoppingRepository()
        {
            Context = new MobileShopEntities();
        }

        public ShoppingM Delete(int id)
        {
            Shopping shopping = Context.Shoppings.SingleOrDefault(x => x.Id == id);
            Context.Shoppings.Remove(shopping);
            Context.SaveChanges();

            return new ShoppingM()
            {
                Id = shopping.Id,
                CustomerId = shopping.CustomerId ?? -1,
                MobileId = shopping.MobileId ?? -1,
                Price = shopping.Price ?? 0,
                ShopId = shopping.ShopId ?? -1,
                Status = shopping.ShoppingStatus,
                Date = shopping.PurchasingDate ?? DateTime.Now,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ShoppingM Edit(ShoppingM shopping)
        {
            var found = Context.Shoppings.SingleOrDefault(x => x.Id == shopping.Id);
            if (found == null)
            {
                return null;
            }
            found.CustomerId = shopping.CustomerId;
            found.MobileId = shopping.MobileId;
            found.Price = shopping.Price;
            found.ShopId = shopping.ShopId;
            found.ShoppingStatus = shopping.Status;
            found.PurchasingDate = shopping.Date;
            Context.SaveChanges();

            return shopping;
        }

        public IEnumerable<ShoppingM> FindAll()
        {
            List<ShoppingM> retVal = new List<ShoppingM>();
            foreach (Shopping shopping in Context.Shoppings.ToList())
            {
                retVal.Add(new ShoppingM()
                {
                    Id = shopping.Id,
                    CustomerId = shopping.CustomerId ?? -1,
                    MobileId = shopping.MobileId ?? -1,
                    Price = shopping.Price ?? 0,
                    ShopId = shopping.ShopId ?? -1,
                    Status = shopping.ShoppingStatus,
                    Date = shopping.PurchasingDate ?? DateTime.Now,
                });
            }

            return retVal;
        }

        public ShoppingM FindById(int id)
        {
            Shopping shopping = Context.Shoppings.SingleOrDefault(x => x.Id == id);

            if (shopping == null)
            {
                return null;
            }

            return new ShoppingM()
            {
                Id = shopping.Id,
                CustomerId = shopping.CustomerId ?? -1,
                MobileId = shopping.MobileId ?? -1,
                Price = shopping.Price ?? 0,
                ShopId = shopping.ShopId ?? -1,
                Status = shopping.ShoppingStatus,
                Date = shopping.PurchasingDate ?? DateTime.Now,
            };
        }

        public ShoppingM Save(ShoppingM shopping)
        {
            Shopping shoppingDb = new Shopping()
            {
                CustomerId = shopping.CustomerId,
                MobileId = shopping.MobileId,
                Price = shopping.Price,
                ShopId = shopping.ShopId,
                ShoppingStatus = shopping.Status,
                PurchasingDate = DateTime.Now,
            };
            Context.Shoppings.Add(shoppingDb);
            Context.SaveChanges();
            shopping.Id = shoppingDb.Id;
            return shopping;
        }
    }
}
