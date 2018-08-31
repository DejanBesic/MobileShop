using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICommunicationRepository : IDisposable
    {
        IEnumerable<CommunicationM> FindAll();
        CommunicationM FindById(int id);
        CommunicationM Save(CommunicationM comm);
        CommunicationM Delete(int id);
        CommunicationM Edit(CommunicationM comm);
    }
}
