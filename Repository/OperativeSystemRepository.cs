using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class OperativeSystemRepository : IOperativeSystemRepository
    {
        private readonly MobileShopEntities Context;

        public OperativeSystemRepository()
        {
            Context = new MobileShopEntities();
        }

        public OperativeSystemM Delete(int id)
        {
            OperativeSystem os = Context.OperativeSystems.SingleOrDefault(x => x.Id == id);
            Context.OperativeSystems.Remove(os);
            Context.SaveChanges();

            return new OperativeSystemM()
            {
                Id = os.Id,
                OS = os.OS,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public OperativeSystemM Edit(OperativeSystemM OS)
        {
            var found = Context.OperativeSystems.SingleOrDefault(x => x.Id == OS.Id);
            if (found == null)
            {
                return null;
            }
            found.OS = OS.OS;
            Context.SaveChanges();

            return OS;
        }

        public IEnumerable<OperativeSystemM> FindAll()
        {
            List<OperativeSystemM> retVal = new List<OperativeSystemM>();
            foreach (OperativeSystem b in Context.OperativeSystems.ToList())
            {
                retVal.Add(new OperativeSystemM() { Id = b.Id, OS = b.OS });
            }

            return retVal;
        }

        public OperativeSystemM FindById(int id)
        {
            OperativeSystem os = Context.OperativeSystems.SingleOrDefault(x => x.Id == id);

            return new OperativeSystemM() { Id = os.Id, OS = os.OS };
        }

        public OperativeSystemM Save(OperativeSystemM OS)
        {
            OperativeSystem osDb = new OperativeSystem()
            {
                OS = OS.OS,
            };
            osDb = Context.OperativeSystems.Add(osDb);
            Context.SaveChanges();
            OS.Id = osDb.Id;
            return OS;
        }
    }
}
