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
    public class CommunicationService : ICommunicationService
    {
        private readonly CommunicationRepository communicationRepository;

        public CommunicationService()
        {
            communicationRepository = new CommunicationRepository();
        }

        public CommunicationM Delete(int id)
        {
            return communicationRepository.Delete(id);
        }

        public CommunicationM Edit(CommunicationM comm)
        {
            return communicationRepository.Edit(comm);
        }

        public IEnumerable<CommunicationM> FindAll()
        {
            return communicationRepository.FindAll();
        }

        public CommunicationM FindById(int id)
        {
            return communicationRepository.FindById(id);
        }

        public CommunicationM Save(CommunicationM comm)
        {
            return communicationRepository.Save(comm);
        }
    }
}
