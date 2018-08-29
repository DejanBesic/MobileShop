using IServices;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.IdentityModel.Tokens;
using Models;
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
        private readonly CustomerRepository customerRepository = new CustomerRepository();

        public bool Authenticate(string email, string password)
        {
            CustomerM customer = customerRepository.FindByEmail(email);
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
    }
}
