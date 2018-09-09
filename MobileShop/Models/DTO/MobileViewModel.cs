using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class MobileViewModel
    {
        public MobileM Mobile { get; set; }

        public DropDowns DropDowns { get; set; }

        public MobileViewModel()
        {

        }
    }
}