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


        [JwtAuthorize]
        public ActionResult Index()
        {
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);
            
            return View(shoppingService.FindAll().Where(x => x.CustomerId == customer.Id && x.Status == "Active"));
        }

        [HttpPut]
        [JwtAuthorize]
        public ActionResult Buy()
        {
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);
            foreach (var shopping in shoppingService.FindAll().Where(x => x.CustomerId == customer.Id && x.Status == "Active"))
            {
                shopping.Status = "Pending";
                shoppingService.Edit(shopping);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        [JwtAuthorize]
        public ActionResult Remove(int id)
        {
            ShoppingM shopping = shoppingService.FindById(id);
            if (shopping == null || shopping.Status != "Active" || shoppingService.Delete(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }       

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPut]
        [JwtAuthorize(Role ="ADMIN")]
        public ActionResult Accept(int id)
        {
            ShoppingM shopping = shoppingService.FindById(id);
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);
            ShopMobilesM shopMobiles = shopMobilesService.FindByShopAndMobile(shopping.ShopId, shopping.MobileId);

            if (shopping == null || shopping.Status != "Pending" || shopMobiles != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (shopping.ShopId != customer.ShopAdminId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            shopping.Status = "Accepted";
            shoppingService.Edit(shopping);
            shopMobiles.MobilesLeft--;
            shopMobilesService.Edit(shopMobiles);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPut]
        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Decline(int id)
        {
            ShoppingM shopping = shoppingService.FindById(id);
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);

            if (shopping == null || shopping.Status != "Pending")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (shopping.ShopId != customer.ShopAdminId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            shopping.Status = "Declined";
            shoppingService.Edit(shopping);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Pendings()
        {
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);

            return View(shoppingService.FindAll().Where(x=> x.ShopId == customer.Id && x.Status == "Pending"));
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

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}