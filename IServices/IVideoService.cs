using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IVideoService : IService
    {
        IEnumerable<VideoM> FindAll();
        VideoM FindById(int id);
        VideoM Save(VideoM video);
        VideoM Delete(int id);
        VideoM Edit(VideoM video);
    }
}
