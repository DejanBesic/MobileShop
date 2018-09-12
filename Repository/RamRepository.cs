using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class RamRepository : IRamRepository
    {
        private readonly MobileShopEntities Context;

        public RamRepository()
        {
            Context = new MobileShopEntities();
        }

        public RamM Delete(int id)
        {
            RAM ram = Context.RAMs.SingleOrDefault(x => x.Id == id);
            Context.RAMs.Remove(ram);
            Context.SaveChanges();

            return new RamM()
            {
                Id = ram.Id,
                Memory = ram.Memory
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public RamM Edit(RamM ram)
        {
            var found = Context.RAMs.SingleOrDefault(x => x.Id == ram.Id);
            if (found == null)
            {
                return null;
            }
            found.Memory = ram.Memory;
            Context.SaveChanges();

            return ram;
        }

        public IEnumerable<RamM> FindAll()
        {
            List<RamM> retVal = new List<RamM>();
            foreach (RAM b in Context.RAMs.ToList())
            {
                retVal.Add(new RamM() { Id = b.Id, Memory = b.Memory });
            }

            return retVal;
        }

        public RamM FindById(int id)
        {
            RAM ram = Context.RAMs.SingleOrDefault(x => x.Id == id);
            if (ram == null)
            {
                return null;
            }

            return new RamM() { Id = ram.Id, Memory = ram.Memory};
        }

        public RamM Save(RamM ram)
        {
            RAM ramDb = new RAM()
            {
                Memory = ram.Memory
            };
            ramDb = Context.RAMs.Add(ramDb);
            Context.SaveChanges();
            ram.Id = ramDb.Id;
            return ram;
        }
    }
}
