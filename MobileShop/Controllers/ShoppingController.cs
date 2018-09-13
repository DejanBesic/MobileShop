using MobileShop.JWT;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly MobileService mobileService = new MobileService();
        private readonly AuthService authService = new AuthService();
        private readonly ShopService shopService = new ShopService();
        private readonly ShopMobilesService shopMobilesService = new ShopMobilesService();
        private readonly ShoppingService shoppingService = new ShoppingService();


        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [JwtAuthorize]
        public ActionResult Add(ShoppingM shopping)
        {
            MobileM mobile = mobileService.FindById(shopping.MobileId);
            ShopM shop = shopService.FindById(shopping.ShopId);
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);
            ShopMobilesM shopMobiles = shopMobilesService.FindByShopAndMobile(shop.Id, mobile.Id);

            if (!ModelState.IsValid || mobile == null || shop == null 
                || customer == null || shopMobiles == null || shopping.Price != shopMobiles.Price)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopping.CustomerId = customer.Id;
            shopping.Status = "Active";
            shoppingService.Save(shopping);

            return new HttpStatusCodeResult(200);
        }
    }
}