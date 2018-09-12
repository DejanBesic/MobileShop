using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IImageRepository : IDisposable
    {
        IEnumerable<ImagesM> FindAll();
        ImagesM FindById(int id);
        ImagesM Save(ImagesM image);
        ImagesM Delete(int id);
        ImagesM Edit(ImagesM image);
        IEnumerable<ImagesM> FindByMobile(int mobileId);
    }
}
