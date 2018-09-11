using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class MobileShopDTO
    {
        public int MobileId { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public MobileShopDTO()
        {

        }
    }
}