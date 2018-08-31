using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IScreenService : IService
    {
        IEnumerable<ScreenM> FindAll();
        ScreenM FindById(int id);
        ScreenM Save(ScreenM screen);
        ScreenM Delete(int id);
        ScreenM Edit(ScreenM screen);
    }
}
