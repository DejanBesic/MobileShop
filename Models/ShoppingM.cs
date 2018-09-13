using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShoppingM
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
    
        public int ShopId { get; set; }

        public int MobileId { get; set; }

        public string Status { get; set; }

        public double Price { get; set; }

        public ShoppingM()
        {

        }
    }
}
