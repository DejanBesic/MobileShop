using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IPackageContentRepository : IDisposable
    {
        IEnumerable<PackageContentM> FindAll();
        PackageContentM FindById(int id);
        PackageContentM Save(PackageContentM package);
        PackageContentM Delete(int id);
        PackageContentM Edit(PackageContentM package);
    }
}
