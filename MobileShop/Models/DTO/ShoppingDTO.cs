using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class ShoppingDTO
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public int Amount { get; set; }

        public int MobilesLeft { get; set; }

        public string MobileName { get; set; }

        public double Price { get; set; }

        public ShoppingDTO()
        {

        }
    }
}