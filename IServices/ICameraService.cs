using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICameraService : IService
    {
        IEnumerable<CameraM> FindAll();
        CameraM FindById(int id);
        CameraM Save(CameraM camera);
        CameraM Delete(int id);
        CameraM Edit(CameraM camera);
    }
}
