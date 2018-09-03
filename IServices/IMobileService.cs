using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IMobileService : IService
    {
        IEnumerable<MobileM> FindAll();
        MobileM FindById(int id);
        MobileM Save(MobileM mobile);
        MobileM Delete(int id);
        MobileM Edit(MobileM mobile);
    }
}
