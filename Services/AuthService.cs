using IServices;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.IdentityModel.Tokens;
using Models;
using Newtonsoft.Json.Linq;
using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly CustomerService customerService;

        public AuthService()
        {
            customerService = new CustomerService();
        }

        public bool Authenticate(string email, string password)
        {
            CustomerM customer = customerService.FindByEmail(email);
            if (customer.Password != password)
            {
                return false;
            }

            return true;
        }

        public string GenerateJWT(CustomerM customer)
        {
            return new JwtBuilder()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"])).ToString())
            .AddClaim("exp", DateTimeOffset.UtcNow.AddMonths(1).ToUnixTimeSeconds())
            .AddClaim("email", customer.Email)
            .AddClaim("id", customer.Id)
            .AddClaim("isAdmin", customer.IsAdmin)
            .Build();
        }

        public CustomerM DecodeJWT(string jwt)
        {
            CustomerM customer = new CustomerM();
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(jwt, new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"])).ToString(), verify: true);
                customer = customerService.FindById((int) JObject.Parse(json)["Id"]);
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                return null;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Jwt token.");
                return null;
            }

            return customer;
        }
    }
}
