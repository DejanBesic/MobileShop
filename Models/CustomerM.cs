using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool Blocked { get; set; }

        public bool Activated { get; set; }

        public bool IsAdmin { get; set; }

        public int ShopAdminId { get; set; }

        public bool IsRootAdmin { get; set; }

        public CustomerM()
        {

        }

    }
}
