using MobileShop.Models;
using Models;
using Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MobileShop.Controllers
{
    public class AuthController : Controller
    {
        private readonly CustomerService customerService = new CustomerService();

        private readonly AuthService authService = new AuthService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            CustomerM customer = customerService.FindByEmail(login.Email);
            if (customer == null || !authService.Authenticate(login.Email, login.Password))
            {
                return Json("Wrong email address or password.", JsonRequestBehavior.AllowGet);
            }

            var token = authService.GenerateJWT(customer);
            FormsAuthentication.SetAuthCookie(token, true);
            var httpContext = HttpContext.ApplicationInstance as MvcApplication;
            HttpCookie cookie = null;
            if (customer.IsAdmin)
            {
                cookie = new HttpCookie("Role", "ADMIN");
            }
            else
            {
                cookie = new HttpCookie("Role", "REGULAR");
            }
            cookie.Expires.AddMonths(1);
            httpContext.Response.Cookies.Set(cookie);

            return Redirect("/Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var httpContext = HttpContext.ApplicationInstance as MvcApplication;
            HttpContext.Response.SetCookie(new HttpCookie("Role", ""));
            return Redirect("/Auth/Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDTO register)
        {
            var customer = customerService.FindByEmail(register.Email);

            if (customer != null || register.Password != register.ConfirmPassword)
            {
                return new HttpStatusCodeResult(400);
            }

            CustomerM newCustomer = new CustomerM()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Address = register.Address,
                Email = register.Email,
                Password = register.Password,
                Blocked = false,
                Activated = false,
                IsAdmin = false,
            };

            customerService.Save(newCustomer);

            var token = authService.GenerateJWT(newCustomer);
            FormsAuthentication.SetAuthCookie(token, true);

            return Redirect("/Home");
        }
    }
}