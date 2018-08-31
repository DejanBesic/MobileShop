using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISoundService : IService
    {
        IEnumerable<SoundM> FindAll();
        SoundM FindById(int id);
        SoundM Save(SoundM sound);
        SoundM Delete(int id);
        SoundM Edit(SoundM sound);
    }
}
