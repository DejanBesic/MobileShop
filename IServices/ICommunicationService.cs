using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICommunicationService : IService
    {
        IEnumerable<CommunicationM> FindAll();
        CommunicationM FindById(int id);
        CommunicationM Save(CommunicationM comm);
        CommunicationM Delete(int id);
        CommunicationM Edit(CommunicationM comm);
    }
}
