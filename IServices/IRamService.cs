using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IRamService : IService
    {
        IEnumerable<RamM> FindAll();
        RamM FindById(int id);
        RamM Save(RamM ram);
        RamM Delete(int id);
        RamM Edit(RamM ram);
    }
}
