using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class MobileController : Controller
    {
        private AdditionalRepository rep = new AdditionalRepository();

        public JsonResult Index()
        {
            return Json(rep.Cameras.SingleOrDefault(x => x.Id == 1), JsonRequestBehavior.AllowGet);
        }
    }
}