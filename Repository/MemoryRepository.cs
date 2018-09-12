using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MemoryRepository : IMemoryRepository
    {
        private readonly MobileShopEntities Context;

        public MemoryRepository()
        {
            Context = new MobileShopEntities();
        }

        public MemoryM Delete(int id)
        {
            Memory memoryDb = Context.Memories.SingleOrDefault(x => x.Id == id);
            if (memoryDb == null)
            {
                return null;
            }
            Context.Memories.Remove(memoryDb);
            Context.SaveChanges();

            return new MemoryM()
            {
                Id = memoryDb.Id,
                Size = memoryDb.Size,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MemoryM Edit(MemoryM memory)
        {
            var found = Context.Memories.SingleOrDefault(x => x.Id == memory.Id);
            if (found == null)
            {
                return null;
            }

            found.Size = memory.Size;
            Context.SaveChanges();
            return memory;
        }

        public IEnumerable<MemoryM> FindAll()
        {
            List<MemoryM> retVal = new List<MemoryM>();
            foreach (Memory m in Context.Memories.ToList())
            {
                retVal.Add(new MemoryM()
                {
                    Id = m.Id,
                    Size = m.Size,
                });
            }

            return retVal;
        }

        public MemoryM FindById(int id)
        {
            Memory memoryDb = Context.Memories.SingleOrDefault(x => x.Id == id);

            if (memoryDb == null)
            {
                return null;
            }

            return new MemoryM()
            {
                Id = memoryDb.Id,
                Size = memoryDb.Size,
            };
        }

        public MemoryM Save(MemoryM memory)
        {
            Memory memoryDb = new Memory()
            {
                Size = memory.Size,
            };
            Context.Memories.Add(memoryDb);
            Context.SaveChanges();
            memory.Id = memoryDb.Id;
            return memory;
        }
    }
}
