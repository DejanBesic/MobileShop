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
    public class MobileService : IMobileService
    {
        private readonly MobileRepository mobileRepository;

        public MobileService()
        {
            mobileRepository = new MobileRepository();
        }

        public MobileM Delete(int id)
        {
            return mobileRepository.Delete(id);
        }

        public MobileM Edit(MobileM mobile)
        {
            return mobileRepository.Edit(mobile);
        }

        public IEnumerable<MobileM> FindAll()
        {
            return mobileRepository.FindAll();
        }

        public MobileM FindById(int id)
        {
            return mobileRepository.FindById(id);
        }

        public MobileM Save(MobileM mobile)
        {
            return mobileRepository.Save(mobile);
        }
    }
}
