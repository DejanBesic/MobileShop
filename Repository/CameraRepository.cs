using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CameraRepository : ICameraRepository
    {
        private readonly MobileShopEntities Context;

        public CameraRepository()
        {
            Context = new MobileShopEntities();
        }

        public CameraM Delete(int id)
        {
            Camera cam = Context.Cameras.SingleOrDefault(x => x.Id == id);
            Context.Cameras.Remove(cam);
            Context.SaveChanges();

            return new CameraM()
            {
                Id = cam.Id,
                MP = cam.MP,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CameraM Edit(CameraM camera)
        {
            var found = Context.Cameras.SingleOrDefault(x => x.Id == camera.Id);
            if (found == null)
            {
                return null;
            }
            found.MP = camera.MP;
            Context.SaveChanges();

            return camera;
        }

        public IEnumerable<CameraM> FindAll()
        {
            List<CameraM> retVal = new List<CameraM>();
            foreach (Camera cam in Context.Cameras.ToList())
            {
                retVal.Add(new CameraM()
                {
                    Id = cam.Id,
                    MP = cam.MP,
                });
            }

            return retVal;
        }

        public CameraM FindById(int id)
        {
            Camera camera = Context.Cameras.SingleOrDefault(x => x.Id == id);

            if (camera == null)
            {
                return null;
            }

            return new CameraM(){ Id = camera.Id, MP = camera.MP };
        }

        public CameraM Save(CameraM camera)
        {
            Camera cameraDb = new Camera()
            {
                Id = camera.Id,
                MP = camera.MP,
            };
            Context.Cameras.Add(cameraDb);
            Context.SaveChanges();
            camera.Id = cameraDb.Id;
            return camera;
        }
    }
}
