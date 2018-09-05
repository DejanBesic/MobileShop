using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class CameraMPRepository : ICameraMPRepository
    {
        private readonly MobileShopEntities Context;

        public CameraMPRepository()
        {
            Context = new MobileShopEntities();
        }
        public CameraMPM Delete(int id)
        {
            CameraMP cam = Context.CameraMPs.SingleOrDefault(x => x.Id == id);
            Context.CameraMPs.Remove(cam);
            Context.SaveChanges();

            return new CameraMPM()
            {
                Id = cam.Id,
                MP = cam.MP
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CameraMPM Edit(CameraMPM mp)
        {
            var found = Context.CameraMPs.SingleOrDefault(x => x.Id == mp.Id);
            if (found == null)
            {
                return null;
            }
            found.MP = mp.MP;
            Context.SaveChanges();

            return mp;
        }

        public IEnumerable<CameraMPM> FindAll()
        {
            List<CameraMPM> retVal = new List<CameraMPM>();
            foreach (CameraMP b in Context.CameraMPs.ToList())
            {
                retVal.Add(new CameraMPM() { Id = b.Id, MP = b.MP });
            }

            return retVal;
        }

        public CameraMPM FindById(int id)
        {
            CameraMP cam = Context.CameraMPs.SingleOrDefault(x => x.Id == id);

            return new CameraMPM() { Id = cam.Id, MP = cam.MP };
        }

        public CameraMPM Save(CameraMPM mp)
        {
            CameraMP camDb = new CameraMP()
            {
                MP = mp.MP,
            };
            camDb = Context.CameraMPs.Add(camDb);
            Context.SaveChanges();
            mp.Id = camDb.Id;
            return mp;
        }
    }
}
