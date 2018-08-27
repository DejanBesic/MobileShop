using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IServices
{
    public interface IAdditionalService : IService
    {
        IEnumerable<AdditionalM> FindAll();

        AdditionalM FindById(int id);

        AdditionalM Save(AdditionalM additional);
    }
}
