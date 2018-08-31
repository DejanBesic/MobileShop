using JWT.Algorithms;
using JWT.Builder;
using Microsoft.IdentityModel.Tokens;
using MobileShop.Models;
using Models;
using Services;
using System;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class AuthController : Controller
    {
        private readonly CustomerService customerService = new CustomerService();

        private readonly AuthService authService = new AuthService();

        [HttpPost]
        public JsonResult Login(LoginDTO login)
        {
            CustomerM customer = customerService.FindByEmail(login.Email);
            if (customer == null || !authService.Authenticate(login.Email, login.Password))
            {
                return Json("Wrong email address or password.", JsonRequestBehavior.AllowGet);
            }

            var tokenString = authService.GenerateJWT(customer);

            var httpContext = HttpContext.ApplicationInstance as MvcApplication;
            var asd = Request.Cookies["JwtToken"];
            HttpCookie cookie = new HttpCookie("JwtToken", tokenString);
            cookie.Expires.AddMonths(1);

            httpContext.Response.Cookies.Add(cookie);
            return Json(tokenString, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Logout()
        {
            var asd = Request.Cookies["JwtToken"];
            var httpContext = HttpContext.ApplicationInstance as MvcApplication;
            HttpContext.Response.SetCookie(new HttpCookie("JwtToken", ""));
        }

        [HttpPost]
        public ActionResult Register(RegisterDTO register)
        {
            var customer = customerService.FindByEmail(register.Email);

            if ( customer != null || register.Password != register.ConfirmPassword)
            {
                return new HttpStatusCodeResult(400);
            }

            customerService.Save(new CustomerM()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Address = register.Address,
                Email = register.Email,
                Password = register.Password,
                Blocked = false,
                Activated = false,
                IsAdmin = false,
            });

            return new HttpStatusCodeResult(200);
        }
    }
}