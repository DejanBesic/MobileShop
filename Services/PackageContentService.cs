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
    public class PackageContentService : IPackageContentService
    {
        private readonly PackageContentRepository packageRepository;

        public PackageContentService()
        {
            packageRepository = new PackageContentRepository();
        }

        public PackageContentM Delete(int id)
        {
            return packageRepository.Delete(id);
        }

        public PackageContentM Edit(PackageContentM package)
        {
            return packageRepository.Edit(package);
        }

        public IEnumerable<PackageContentM> FindAll()
        {
            return packageRepository.FindAll();
        }

        public PackageContentM FindById(int id)
        {
            return packageRepository.FindById(id);
        }

        public PackageContentM Save(PackageContentM package)
        {
            return packageRepository.Save(package);
        }
    }
}
