using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using Models;

namespace Repository
{
    public class AdditionalRepository : IAdditionalRepository
    {
        private readonly MobileShopEntities Context = new MobileShopEntities();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdditionalM> FindAll()
        {
            List<AdditionalM> retVal = new List<AdditionalM>();
            foreach (Additional a in Context.Additionals.ToList())
            {
                retVal.Add(new AdditionalM(a.Id, a.AdditionalDescription));
            }

            return retVal;
        }

        public AdditionalM FindById(int id)
        {
            Additional found = Context.Additionals.SingleOrDefault(x => x.Id == id);
            if (found == null)
            {
                return null;
            }

            return new AdditionalM(found.Id, found.AdditionalDescription);
        }

        public AdditionalM Save(AdditionalM additional)
        {
            Additional additionalDb = new Additional()
            {
                AdditionalDescription = additional.Description,
            };
            Context.Additionals.Add(additionalDb);
            Context.SaveChanges();
            additional.Id = additionalDb.Id;
            return additional;
        }

        public AdditionalM Delete(int id)
        {
            Additional additionalDb = Context.Additionals.Single(x => x.Id == id);
            if (additionalDb == null)
            {
                return null;
            }

            Context.Additionals.Remove(additionalDb);
            Context.SaveChanges();

            return new AdditionalM(additionalDb.Id, additionalDb.AdditionalDescription);
        }

        public AdditionalM Edit(AdditionalM additional)
        {
            var found = Context.Additionals.SingleOrDefault(x => x.Id == additional.Id);
            if (found == null)
            {
                return null;
            }
            found.AdditionalDescription = additional.Description;
            Context.SaveChanges();

            return additional;
        }
    }
}
