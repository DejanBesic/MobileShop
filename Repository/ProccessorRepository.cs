using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Properties;

namespace Repository
{
    public class ProccessorRepository : IProccessorRepository
    {
        private readonly MobileShopEntities Context;

        public ProccessorRepository()
        {
            Context = new MobileShopEntities();
        }

        public ProccessorM Delete(int id)
        {
            Proccessor proccessor = Context.Proccessors.SingleOrDefault(x => x.Id == id);
            Context.Proccessors.Remove(proccessor);
            Context.SaveChanges();

            return new ProccessorM()
            {
                Id = proccessor.Id,
                Characteristics = proccessor.ProccessorChars
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ProccessorM Edit(ProccessorM proccessor)
        {
            var found = Context.Proccessors.SingleOrDefault(x => x.Id == proccessor.Id);
            if (found == null)
            {
                return null;
            }
            found.ProccessorChars = proccessor.Characteristics;
            Context.SaveChanges();

            return proccessor;
        }

        public IEnumerable<ProccessorM> FindAll()
        {
            List<ProccessorM> retVal = new List<ProccessorM>();
            foreach (Proccessor b in Context.Proccessors.ToList())
            {
                retVal.Add(new ProccessorM() { Id = b.Id, Characteristics = b.ProccessorChars });
            }

            return retVal;
        }

        public ProccessorM FindById(int id)
        {
            Proccessor proccessor = Context.Proccessors.SingleOrDefault(x => x.Id == id);

            return new ProccessorM() { Id = proccessor.Id, Characteristics = proccessor.ProccessorChars};
        }

        public ProccessorM Save(ProccessorM proccessor)
        {
            Proccessor proccessorDb = new Proccessor()
            {
                ProccessorChars = proccessor.Characteristics,
            };
            proccessorDb = Context.Proccessors.Add(proccessorDb);
            Context.SaveChanges();
            proccessor.Id = proccessorDb.Id;
            return proccessor;
        }
    }
}
