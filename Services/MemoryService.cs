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
    public class MemoryService : IMemoryService
    {
        private readonly MemoryRepository memoryRepository;

        public MemoryService()
        {
            memoryRepository = new MemoryRepository();
        }

        public MemoryM Delete(int id)
        {
            return memoryRepository.Delete(id);
        }

        public MemoryM Edit(MemoryM memory)
        {
            return memoryRepository.Edit(memory);
        }

        public IEnumerable<MemoryM> FindAll()
        {
            return memoryRepository.FindAll();
        }

        public MemoryM FindById(int id)
        {
            return memoryRepository.FindById(id);
        }

        public MemoryM Save(MemoryM memory)
        {
            return memoryRepository.Save(memory);
        }
    }
}
