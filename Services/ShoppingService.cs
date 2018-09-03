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
    public class ShoppingService : IShoppingService
    {
        private readonly ShoppingRepository shoppingRepository;

        public ShoppingService()
        {
            shoppingRepository = new ShoppingRepository();
        }

        public ShoppingM Delete(int id)
        {
            return shoppingRepository.Delete(id);
        }

        public ShoppingM Edit(ShoppingM shopping)
        {
            return shoppingRepository.Edit(shopping);
        }

        public IEnumerable<ShoppingM> FindAll()
        {
            return shoppingRepository.FindAll();
        }

        public ShoppingM FindById(int id)
        {
            return shoppingRepository.FindById(id);
        }

        public ShoppingM Save(ShoppingM shopping)
        {
            return shoppingRepository.Save(shopping);
        }
    }
}
