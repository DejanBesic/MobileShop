using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PhonePlatformRepository : IPhonePlatformRepository
    {
        private readonly MobileShopEntities Context;

        public PhonePlatformRepository()
        {
            Context = new MobileShopEntities();
        }

        public PhonePlatformM Delete(int id)
        {
            PhonePlatform platform = Context.PhonePlatforms.SingleOrDefault(x => x.Id == id);
            Context.PhonePlatforms.Remove(platform);
            Context.SaveChanges();

            return new PhonePlatformM()
            {
                Id = platform.Id,
                OS = platform.OS,
                RAM = platform.RAM
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PhonePlatformM Edit(PhonePlatformM platform)
        {
            var found = Context.PhonePlatforms.SingleOrDefault(x => x.Id == platform.Id);
            if (found == null)
            {
                return null;
            }
            found.OS = platform.OS;
            found.RAM = platform.RAM;
            Context.SaveChanges();

            return platform;
        }

        public IEnumerable<PhonePlatformM> FindAll()
        {
            List<PhonePlatformM> retVal = new List<PhonePlatformM>();
            foreach (PhonePlatform p in Context.PhonePlatforms.ToList())
            {
                retVal.Add(new PhonePlatformM()
                {
                    Id = p.Id,
                    OS = p.OS,
                    RAM = p.RAM
                });
            }

            return retVal;
        }

        public PhonePlatformM FindById(int id)
        {
            PhonePlatform platform = Context.PhonePlatforms.SingleOrDefault(x => x.Id == id);

            return new PhonePlatformM()
            {
                Id = platform.Id,
                OS = platform.OS,
                RAM = platform.RAM
            };
        }

        public PhonePlatformM Save(PhonePlatformM platform)
        {
            PhonePlatform platformDb = new PhonePlatform()
            {
                OS = platform.OS,
                RAM = platform.RAM
            };
            Context.PhonePlatforms.Add(platformDb);
            Context.SaveChanges();
            platformDb.Id = platformDb.Id;
            return platform;
        }
    }
}
