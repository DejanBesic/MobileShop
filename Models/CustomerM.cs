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

        public int BlockedBy { get; set; }

        public CustomerM()
        {

        }

        public CustomerM(int id, string firstName, string lastName, string address, string email, bool? blocked, bool? activated, bool? isAdmin, int? blockedBy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            Blocked = blocked ?? false;
            activated = activated ?? false;
            IsAdmin = isAdmin ?? false;
            BlockedBy = blockedBy ?? -1;
        }

    }
}
