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
    public class CartService : ICartService
    {
        private readonly CartRepository cartRepository;

        public CartService()
        {
            cartRepository = new CartRepository();
        }

        public CartM Delete(int id)
        {
            return cartRepository.Delete(id);
        }

        public CartM Edit(CartM cart)
        {
            return cartRepository.Edit(cart);
        }

        public IEnumerable<CartM> FindAll()
        {
            return cartRepository.FindAll();
        }

        public IEnumerable<CartM> FindByCustomer(int id)
        {
            return cartRepository.FindByCustomer(id);
        }

        public CartM FindById(int id)
        {
            return cartRepository.FindById(id);
        }

        public CartM Save(CartM cart)
        {
            return cartRepository.Save(cart);
        }
    }
}
