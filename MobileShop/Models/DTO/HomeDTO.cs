using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class HomeDTO
    {
        public DropDowns Drops { get; set; }

        public IEnumerable<HomeMobile> Mobile { get; set; }

        public HomeDTO()
        {

        }
    }
}