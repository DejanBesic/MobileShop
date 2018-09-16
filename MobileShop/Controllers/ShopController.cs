using MobileShop.JWT;
using MobileShop.Models.DTO;
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
        ShoppingService shoppingService = new ShoppingService();
        MobileService mobileService = new MobileService();

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

            return RedirectToAction("Index", "Home");
        }

        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Info()
        {
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);

            ShopM shop = new ShopM();

            if(customer.ShopAdminId != -1)
            {
                shop = shopService.FindById(customer.ShopAdminId);
            }

            return View(shop);
        }

        [HttpPost]
        [JwtAuthorize(Role ="ADMIN")]
        public ActionResult Save(ShopM shop)
        {
            if (ModelState.IsValid)
            {
                shopService.Edit(shop);    
            }

            return RedirectToAction("Info");
        }

        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult History()
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);
            ShopM shop = shopService.FindById(admin.ShopAdminId);
            List<ShoppingDTO> shoppings = new List<ShoppingDTO>();
            foreach (var shopping in shoppingService.FindAll().Where(x => x.ShopId == shop.Id)) {
                shoppings.Add(new ShoppingDTO()
                {
                    Id = shopping.Id,
                    Customer = admin.Email,
                    CustomerId = admin.Id,
                    MobileId = shopping.MobileId,
                    MobileName = mobileService.FindById(shopping.MobileId).Name,
                    Price =shopping.Price,
                    Status = shopping.Status,
                });
            }


            return View(shoppings);
        }
    }
}