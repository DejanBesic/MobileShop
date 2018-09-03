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
                CartId = shopping.CartId ?? -1,
                CustomerId = shopping.CustomerId ?? -1,
                ShoppingNumber = shopping.ShoppingNumber ?? -1,
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
            found.CartId = shopping.CartId;
            found.CustomerId = shopping.CustomerId;
            found.ShoppingNumber = shopping.ShoppingNumber;
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
                    CartId = shopping.CartId ?? -1,
                    CustomerId = shopping.CustomerId ?? -1,
                    ShoppingNumber = shopping.ShoppingNumber ?? -1,
                });
            }

            return retVal;
        }

        public ShoppingM FindById(int id)
        {
            Shopping shopping = Context.Shoppings.SingleOrDefault(x => x.Id == id);

            return new ShoppingM()
            {
                Id = shopping.Id,
                CartId = shopping.CartId ?? -1,
                CustomerId = shopping.CustomerId ?? -1,
                ShoppingNumber = shopping.ShoppingNumber ?? -1,
            };
        }

        public ShoppingM Save(ShoppingM shopping)
        {
            Shopping shoppingDb = new Shopping()
            {
                CartId = shopping.CartId,
                CustomerId = shopping.CustomerId,
                ShoppingNumber = shopping.ShoppingNumber,
            };
            Context.Shoppings.Add(shoppingDb);
            Context.SaveChanges();
            shopping.Id = shoppingDb.Id;
            return shopping;
        }
    }
}
