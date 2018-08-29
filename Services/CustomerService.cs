using IServices;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public CustomerM Delete(int id)
        {
            return customerRepository.Delete(id);
        }

        public CustomerM Edit(CustomerM customer)
        {
            return customerRepository.Edit(customer);
        }

        public IEnumerable<CustomerM> FindAll()
        {
            return customerRepository.FindAll();
        }

        public CustomerM FindByEmail(string email)
        {
            return customerRepository.FindByEmail(email);
        }

        public CustomerM FindById(int id)
        {
            return customerRepository.FindById(id);
        }

        public CustomerM Save(CustomerM customer)
        {
            return customerRepository.Save(customer);
        }

    }
}
