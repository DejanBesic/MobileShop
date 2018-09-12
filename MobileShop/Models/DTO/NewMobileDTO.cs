using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class NewMobileDTO
    {
        public MobileM Mobile { get; set; }

        public IEnumerable<HttpPostedFileBase> Images { get; set; }

        public NewMobileDTO()
        {

        }
    }
}