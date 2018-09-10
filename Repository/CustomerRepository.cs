using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using Models;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MobileShopEntities Context = new MobileShopEntities();

        public CustomerM Delete(int id)
        {
            Customer customerDb = Context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerDb == null)
            {
                return null;
            }
            Context.Customers.Remove(customerDb);
            Context.SaveChanges();

            return new CustomerM()
            {
                Id = customerDb.Id,
                FirstName = customerDb.FirstName,
                LastName = customerDb.LastName,
                Email = customerDb.Email,
                Address = customerDb.CustomerAddress,
                Blocked = customerDb.Blocked ?? false,
                Activated = customerDb.Activated ?? false,
                IsAdmin = customerDb.IsAdmin ?? false,
                IsRootAdmin = customerDb.IsRootAdmin ?? false,
                ShopAdminId = customerDb.ShopAdminId ?? -1,
            }; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CustomerM Edit(CustomerM customer)
        {
            var found = Context.Customers.SingleOrDefault(x => x.Id == customer.Id);
            if (found == null)
            {
                return null;
            }
            found.FirstName = customer.FirstName;
            found.LastName = customer.LastName;
            found.Email = customer.Email;
            if (customer.Password != null && customer.Password != "")
            {
                found.CustomerPassword = customer.Password;
            }
            found.IsAdmin = customer.IsAdmin;
            found.Blocked = customer.Blocked;
            found.Activated = customer.Activated;
            found.ShopAdminId = customer.ShopAdminId;
            found.IsRootAdmin = customer.IsRootAdmin;
            Context.SaveChanges();
            customer.Password = "";
            return customer;
        }

        public IEnumerable<CustomerM> FindAll()
        {
            List<CustomerM> retVal = new List<CustomerM>();
            foreach (Customer c in Context.Customers.ToList())
            {
                retVal.Add(new CustomerM()
                { 
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Address = c.CustomerAddress,
                    Blocked = c.Blocked ?? false,
                    Activated = c.Activated ?? false,
                    IsAdmin = c.IsAdmin ?? false,
                    ShopAdminId = c.ShopAdminId ?? -1,
                    IsRootAdmin = c.IsRootAdmin ?? false,
                });
            }

            return retVal;
        }

        public CustomerM FindByEmail(string email)
        {
            Customer customerDb = Context.Customers.SingleOrDefault(x => x.Email == email);

            if(customerDb == null)
            {
                return null;
            }

            return new CustomerM()
            {
                Id = customerDb.Id,
                FirstName = customerDb.FirstName,
                LastName = customerDb.LastName,
                Email = customerDb.Email,
                Address = customerDb.CustomerAddress,
                Blocked = customerDb.Blocked ?? false,
                Activated = customerDb.Activated ?? false,
                IsAdmin = customerDb.IsAdmin ?? false,
                Password = customerDb.CustomerPassword,
                ShopAdminId = customerDb.ShopAdminId ?? -1,
                IsRootAdmin = customerDb.IsRootAdmin ?? false,
            };
        }

        public CustomerM FindById(int id)
        {
            Customer customerDb = Context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerDb == null)
            {
                return null;
            }

            return new CustomerM()
            {
                Id = customerDb.Id,
                FirstName = customerDb.FirstName,
                LastName = customerDb.LastName,
                Email = customerDb.Email,
                Address = customerDb.CustomerAddress,
                Blocked = customerDb.Blocked ?? false,
                Activated = customerDb.Activated ?? false,
                IsAdmin = customerDb.IsAdmin ?? false,
                ShopAdminId = customerDb.ShopAdminId ?? -1,
                IsRootAdmin = customerDb.IsRootAdmin ?? false,
            };
        }

        public CustomerM Save(CustomerM customer)
        {
            Customer customerDb = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                CustomerAddress = customer.Address,
                Blocked = customer.Blocked,
                Activated = customer.Activated,
                IsAdmin = customer.IsAdmin,
                CustomerPassword = customer.Password,
                ShopAdminId = null,
                IsRootAdmin = customer.IsRootAdmin,
            };
            Context.Customers.Add(customerDb);
            Context.SaveChanges();
            customer.Id = customerDb.Id;
            return customer;
        }
    }
}
