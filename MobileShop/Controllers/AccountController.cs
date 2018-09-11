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
    public class AccountController : Controller
    {
        CustomerService customerService = new CustomerService();
        AuthService authService = new AuthService();

        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult All()
        {
            CustomerM user = authService.DecodeJWT(User.Identity.Name);

            return View(customerService.FindAll().Where(x => x.ShopAdminId == -1 && x.IsAdmin == false && x.IsRootAdmin == false && x.Id != user.Id));
        }

        [HttpPut]
        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Add(int id)
        {
            CustomerM customer = customerService.FindById(id);
            if (customer != null)
            {
                CustomerM admin = authService.DecodeJWT(User.Identity.Name);
                if (!customer.IsAdmin && customer.ShopAdminId == -1)
                {
                    customer.IsAdmin = true;
                    customer.ShopAdminId = admin.ShopAdminId;
                    customerService.Edit(customer);
                }
            }

            return RedirectToAction("All");
        }

        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Manage()
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);

            return View(customerService.FindAll().Where(x => x.ShopAdminId == admin.ShopAdminId && x.Id != admin.Id));
        }

        [HttpDelete]
        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Remove(int id)
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);
            CustomerM customer = customerService.FindById(id);
            if (customer == null || admin.ShopAdminId != customer.ShopAdminId)
            {
                return RedirectToAction("Manage");
            }
            customer.IsAdmin = false;
            customer.ShopAdminId = -1;
            customerService.Edit(customer);

            return RedirectToAction("Manage");
        }

    }
}