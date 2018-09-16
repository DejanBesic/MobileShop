using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class ShoppingDTO
    {
        public int Id { get; set; }

        public int MobileId { get; set; }

        public int CustomerId { get; set; }

        public string ShopName { get; set; }

        public int ShopId { get; set; }

        public string Customer { get; set; }

        public string MobileName { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }


        public ShoppingDTO()
        {

        }
    }
}