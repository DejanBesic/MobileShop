using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IRepository
{
    public interface IAdditionalRepository : IDisposable
    {
        IEnumerable<AdditionalM> FindAll();
        AdditionalM FindById(int id);
        AdditionalM Save(AdditionalM additional);
        AdditionalM Delete(int id);
        AdditionalM Edit(AdditionalM additional);
    }
}
