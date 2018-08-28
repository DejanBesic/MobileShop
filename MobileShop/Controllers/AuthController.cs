using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public JsonResult Token()
        {
            var claimsdata = new[] { new Claim(ClaimTypes.Name, "username") };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySigningSuperSecretKey"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                  issuer: "mobileshop.com",
                  audience: "mobileshop.com",
                  expires: DateTime.Now.AddMinutes(1000),
                  claims: claimsdata,
                  signingCredentials: signInCred
                  );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Json(tokenString, JsonRequestBehavior.AllowGet);
        }
    }
}