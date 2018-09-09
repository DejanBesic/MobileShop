using System;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;
using JWT;
using JWT.Serializers;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services;

namespace MobileShop.JWT
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorize : AuthorizeAttribute
    {
        public string Role { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = HttpContext.Current.User.Identity.Name;

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"])).ToString(), verify: true);
                if (Role == "ADMIN" && Role != httpContext.Request.Cookies["Role"].Value)
                {
                    
                    return false;
                }
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                return false;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Jwt token.");
                return false;
            }

            return true;
        }
    }
}