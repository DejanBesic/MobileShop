using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class MobileService : IMobileService
    {
        private MobileRepository mobileRepository = new MobileRepository();

        public ICollection<DMobile> FindAll()
        {
           return mobileRepository.FindAll();
        }

        public DMobile FindById(int id)
        {
            throw new NotImplementedException();
        }

        public DMobile Save(DMobile mobile)
        {
            throw new NotImplementedException();
        }
    }
}
