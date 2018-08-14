using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

namespace MobileShop.Controllers
{
    public class MobileController : Controller
    {
        private MobileService mobileService = new MobileService();

        // GET: Mobile
        public ICollection<DMobile> Index()
        {
            return mobileService.FindAll();
        }
    }
}