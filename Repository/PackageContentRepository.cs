using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PackageContentRepository : IPackageContentRepository
    {
        private readonly MobileShopEntities Context;

        public PackageContentRepository()
        {
            Context = new MobileShopEntities();
        }

        public PackageContentM Delete(int id)
        {
            PackageContent package = Context.PackageContents.SingleOrDefault(x => x.Id == id);
            Context.PackageContents.Remove(package);
            Context.SaveChanges();

            return new PackageContentM()
            {
                Id = package.Id,
                Content = package.Content,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PackageContentM Edit(PackageContentM package)
        {
            var found = Context.PackageContents.SingleOrDefault(x => x.Id == package.Id);
            if (found == null)
            {
                return null;
            }
            found.Content = package.Content;
            Context.SaveChanges();

            return package;
        }

        public IEnumerable<PackageContentM> FindAll()
        {
            List<PackageContentM> retVal = new List<PackageContentM>();
            foreach (PackageContent p in Context.PackageContents.ToList())
            {
                retVal.Add(new PackageContentM()
                {
                    Id = p.Id,
                    Content = p.Content,
                });
            }

            return retVal;
        }

        public PackageContentM FindById(int id)
        {
            PackageContent package = Context.PackageContents.SingleOrDefault(x => x.Id == id);

            return new PackageContentM()
            {
                Id = package.Id,
                Content = package.Content,
            };
        }

        public PackageContentM Save(PackageContentM package)
        {
            PackageContent packageDb = new PackageContent()
            {
                Content = package.Content,
            };
            Context.PackageContents.Add(packageDb);
            Context.SaveChanges();
            package.Id = packageDb.Id;
            return package;
        }
    }
}
