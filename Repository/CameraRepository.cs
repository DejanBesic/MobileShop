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
                MP = cam.MpId,
                Characteristics = cam.CharacteristicsId
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
            found.MP = camera.MpId;
            found.Characteristics = camera.CharacteristicsId;
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
                    MP = cam.MpId,
                    Characteristics = cam.CharacteristicsId
                });
            }

            return retVal;
        }

        public CameraM FindById(int id)
        {
            Camera camera = Context.Cameras.SingleOrDefault(x => x.Id == id);

            return new CameraM()
            {
                Id = camera.Id,
                MP = camera.MpId,
                Characteristics = camera.CharacteristicsId
            };
        }

        public CameraM Save(CameraM camera)
        {
            Camera cameraDb = new Camera()
            {
                Id = camera.Id,
                MpId = camera.MP ?? -1,
                CharacteristicsId = camera.CharacteristicsId
            };
            Context.Cameras.Add(cameraDb);
            Context.SaveChanges();
            camera.Id = cameraDb.Id;
            return camera;
        }
    }
}
