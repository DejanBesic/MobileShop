using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class MobileDTO
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public MobileDTO()
        {

        }
    }
}