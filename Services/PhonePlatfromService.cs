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
    public class PhonePlatfromService : IPhonePlatformService
    {
        private readonly PhonePlatformRepository phonePlatformRepository;

        public PhonePlatfromService()
        {
            phonePlatformRepository = new PhonePlatformRepository();
        }

        public PhonePlatformM Delete(int id)
        {
            return phonePlatformRepository.Delete(id);
        }

        public PhonePlatformM Edit(PhonePlatformM platform)
        {
            return phonePlatformRepository.Edit(platform);
        }

        public IEnumerable<PhonePlatformM> FindAll()
        {
            return phonePlatformRepository.FindAll();
        }

        public PhonePlatformM FindById(int id)
        {
            return phonePlatformRepository.FindById(id);
        }

        public PhonePlatformM Save(PhonePlatformM platform)
        {
            return phonePlatformRepository.Save(platform);
        }
    }
}
