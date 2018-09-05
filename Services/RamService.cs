using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class RamService : IRamService
    {
        private readonly RamRepository ramRepository;

        public RamService()
        {
            ramRepository = new RamRepository();
        }

        public RamM Delete(int id)
        {
            return ramRepository.Delete(id);
        }

        public RamM Edit(RamM ram)
        {
            return ramRepository.Edit(ram);
        }

        public IEnumerable<RamM> FindAll()
        {
            return ramRepository.FindAll();
        }

        public RamM FindById(int id)
        {
            return ramRepository.FindById(id);
        }

        public RamM Save(RamM ram)
        {
            return ramRepository.Save(ram);
        }
    }
}
