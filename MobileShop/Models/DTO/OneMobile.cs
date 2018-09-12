using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class OneMobile
    {
        public MobileM Mobile { get; set; }

        public ShopM Shop { get; set; }

        public double Price { get; set; }

        public IEnumerable<string> Images { get; set; }

    }
}