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
    public class CameraService : ICameraService
    {
        private readonly CameraRepository cameraRepository;

        public CameraService()
        {
            cameraRepository = new CameraRepository();
        }

        public CameraM Delete(int id)
        {
            return cameraRepository.Delete(id);
        }

        public CameraM Edit(CameraM camera)
        {
            return cameraRepository.Edit(camera);
        }

        public IEnumerable<CameraM> FindAll()
        {
            return cameraRepository.FindAll();
        }

        public CameraM FindById(int id)
        {
            return cameraRepository.FindById(id);
        }

        public CameraM Save(CameraM camera)
        {
            return cameraRepository.Save(camera);
        }
    }
}
