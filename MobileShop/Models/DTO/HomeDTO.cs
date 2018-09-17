using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class HomeDTO
    {
        public DropDowns Drops { get; set; }

        public IPagedList<HomeMobile> Mobiles { get; set; }

        public HomeDTO()
        {

        }
    }
}