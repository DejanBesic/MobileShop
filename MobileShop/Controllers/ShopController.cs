using MobileShop.JWT;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class ShopController : Controller
    {
        ShopService shopService = new ShopService();
        AuthService authService = new AuthService();
        CustomerService customerService = new CustomerService();

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        [JwtAuthorize]
        public ActionResult New()
        {

            return View(new ShopM());
        }

        [HttpPost]
        [JwtAuthorize]
        public ActionResult Create(ShopM shop)
        {
            if(ModelState.IsValid)
            {
                CustomerM customer = authService.DecodeJWT(User.Identity.Name);
                if (customer.ShopAdminId != -1)
                {
                    return RedirectToAction("New");
                }
                shop = shopService.Save(shop);
                customer.IsAdmin = true;
                customer.ShopAdminId = shop.Id;
                customerService.Edit(customer);
                HttpContext.Response.SetCookie(new HttpCookie("Role", "ADMIN"));
            }

            return RedirectToAction("New");
        }
    }
}