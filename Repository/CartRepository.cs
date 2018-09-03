using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MobileShopEntities Context;

        public CartRepository()
        {
            Context = new MobileShopEntities();
        }

        public CartM Delete(int id)
        {
            Cart cart = Context.Carts.SingleOrDefault(x => x.Id == id);
            Context.Carts.Remove(cart);
            Context.SaveChanges();

            return new CartM()
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId ?? -1,
                ShopMobileId = cart.ShopMobileId ?? -1,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CartM Edit(CartM cart)
        {
            var found = Context.Carts.SingleOrDefault(x => x.Id == cart.Id);
            if (found == null)
            {
                return null;
            }
            found.ShopMobileId = cart.ShopMobileId;
            found.CustomerId = cart.CustomerId;
            Context.SaveChanges();

            return cart;
        }

        public IEnumerable<CartM> FindAll()
        {
            List<CartM> retVal = new List<CartM>();
            foreach (Cart c in Context.Carts.ToList())
            {
                retVal.Add(new CartM()
                {
                    Id = c.Id,
                    ShopMobileId = c.ShopMobileId ?? -1,
                    CustomerId = c.CustomerId ?? -1,
            });
            }

            return retVal;
        }

        public IEnumerable<CartM> FindByCustomer(int id)
        {
            List<CartM> retVal = new List<CartM>();
            foreach (Cart c in Context.Carts.Where(x => x.CustomerId == id))
            {
                retVal.Add(new CartM()
                {
                    Id = c.Id,
                    ShopMobileId = c.ShopMobileId ?? -1,
                    CustomerId = c.CustomerId ?? -1,
                });
            }

            return retVal;
        }

        public CartM FindById(int id)
        {
            Cart cart = Context.Carts.SingleOrDefault(x => x.Id == id);

            return new CartM()
            {
                Id = cart.Id,
                ShopMobileId = cart.ShopMobileId ?? -1,
                CustomerId = cart.CustomerId ?? -1,
            };
        }

        public IEnumerable<CartM> FindByShopMobiles(int id)
        {
            List<CartM> retVal = new List<CartM>();
            foreach (Cart c in Context.Carts.Where(x => x.ShopMobileId == id))
            {
                retVal.Add(new CartM()
                {
                    Id = c.Id,
                    ShopMobileId = c.ShopMobileId ?? -1,
                    CustomerId = c.CustomerId ?? -1,
                });
            }

            return retVal;
        }

        public CartM Save(CartM cart)
        {
            Cart cartDb = new Cart()
            {
                ShopMobileId = cart.ShopMobileId,
                CustomerId = cart.CustomerId,
            };
            Context.Carts.Add(cartDb);
            Context.SaveChanges();
            cart.Id = cartDb.Id;
            return cart;
        }
    }
}
