using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICameraRepository : IDisposable
    {
        IEnumerable<CameraM> FindAll();
        CameraM FindById(int id);
        CameraM Save(CameraM camera);
        CameraM Delete(int id);
        CameraM Edit(CameraM camera);
    }
}
