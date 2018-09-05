using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Properties;
using Repository;

namespace Services
{
    public class ProccessorService : IProccessorService
    {
        private readonly ProccessorRepository proccessorRepository;

        public ProccessorService()
        {
            proccessorRepository = new ProccessorRepository();
        }

        public ProccessorM Delete(int id)
        {
            return proccessorRepository.Delete(id);
        }

        public ProccessorM Edit(ProccessorM proccessor)
        {
            return proccessorRepository.Edit(proccessor);
        }

        public IEnumerable<ProccessorM> FindAll()
        {
            return proccessorRepository.FindAll();
        }

        public ProccessorM FindById(int id)
        {
            return proccessorRepository.FindById(id);
        }

        public ProccessorM Save(ProccessorM proccessor)
        {
            return proccessorRepository.Save(proccessor);
        }
    }
}
