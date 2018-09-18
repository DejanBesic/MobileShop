using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class ChangeAccountInfo : CustomerM
    {
        public string OldPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public ChangeAccountInfo()
        {

        }
    }
}