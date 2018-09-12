using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class HomeMobile
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string Name { get; set; }

        public int ShopId { get; set; }

        public double Price { get; set; }

        public IEnumerable<string> Images { get; set; }

        public HomeMobile()
        {

        }
    }
}