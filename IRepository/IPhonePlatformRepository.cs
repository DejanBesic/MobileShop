using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IPhonePlatformRepository : IDisposable
    {
        IEnumerable<PhonePlatformM> FindAll();
        PhonePlatformM FindById(int id);
        PhonePlatformM Save(PhonePlatformM platform);
        PhonePlatformM Delete(int id);
        PhonePlatformM Edit(PhonePlatformM platform);
    }
}
