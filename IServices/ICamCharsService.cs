using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICamCharsService : IService
    {
        IEnumerable<CameraCharacteristicsM> FindAll();
        CameraCharacteristicsM FindById(int id);
        CameraCharacteristicsM Save(CameraCharacteristicsM chars);
        CameraCharacteristicsM Delete(int id);
        CameraCharacteristicsM Edit(CameraCharacteristicsM chars);
    }
}
