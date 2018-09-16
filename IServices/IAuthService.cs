using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAuthService : IService
    {
        bool Authenticate(string email, string password);
        string GenerateJWT(CustomerM customer);
        CustomerM DecodeJWT(string jwt);
        string HashPassword(string password);
    }
}
