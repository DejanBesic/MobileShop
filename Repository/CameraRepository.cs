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
                BackCamera = cam.BackCamera,
                FrontCamera = cam.FrontCamera,
                BackCameraChar = cam.BackCameraChar,
                FrontCameraChar = cam.FrontCameraChar,
                Video = cam.Video,
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
            found.BackCamera = camera.BackCamera;
            found.FrontCamera = camera.FrontCamera;
            found.BackCameraChar = camera.BackCameraChar;
            found.FrontCameraChar = camera.FrontCameraChar;
            found.Video = camera.Video;
            Context.SaveChanges();

            return camera;
        }

        public IEnumerable<CameraM> FindAll()
        {
            List<CameraM> retVal = new List<CameraM>();
            foreach (Camera c in Context.Cameras.ToList())
            {
                retVal.Add(new CameraM()
                {
                    Id = c.Id,
                    BackCamera = c.BackCamera,
                    FrontCamera = c.FrontCamera,
                    BackCameraChar = c.BackCameraChar,
                    FrontCameraChar = c.FrontCameraChar,
                    Video = c.Video,
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
                BackCamera = camera.BackCamera,
                FrontCamera = camera.FrontCamera,
                BackCameraChar = camera.BackCameraChar,
                FrontCameraChar = camera.FrontCameraChar,
                Video = camera.Video,
            };
        }

        public CameraM Save(CameraM camera)
        {
            Camera cameraDb = new Camera()
            {
                BackCamera = camera.BackCamera,
                FrontCamera = camera.FrontCamera,
                BackCameraChar = camera.BackCameraChar,
                FrontCameraChar = camera.FrontCameraChar,
                Video = camera.Video,
            };
            Context.Cameras.Add(cameraDb);
            Context.SaveChanges();
            camera.Id = cameraDb.Id;
            return camera;
        }
    }
}
