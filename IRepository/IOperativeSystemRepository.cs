using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IOperativeSystemRepository : IDisposable
    {
        IEnumerable<OperativeSystemM> FindAll();
        OperativeSystemM FindById(int id);
        OperativeSystemM Save(OperativeSystemM OS);
        OperativeSystemM Delete(int id);
        OperativeSystemM Edit(OperativeSystemM OS);
    }
}
