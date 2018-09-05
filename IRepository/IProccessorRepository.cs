using Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IProccessorRepository : IDisposable
    {
        IEnumerable<ProccessorM> FindAll();
        ProccessorM FindById(int id);
        ProccessorM Save(ProccessorM proccessor);
        ProccessorM Delete(int id);
        ProccessorM Edit(ProccessorM proccessor);
    }
}
