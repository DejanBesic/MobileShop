using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class OperativeSystemService : IOperativeSystemService
    {
        private readonly OperativeSystemRepository operativeSystemRepository;

        public OperativeSystemService()
        {
            operativeSystemRepository = new OperativeSystemRepository();
        }

        public OperativeSystemM Delete(int id)
        {
            return operativeSystemRepository.Delete(id);
        }

        public OperativeSystemM Edit(OperativeSystemM OS)
        {
            return operativeSystemRepository.Edit(OS);
        }

        public IEnumerable<OperativeSystemM> FindAll()
        {
            return operativeSystemRepository.FindAll();
        }

        public OperativeSystemM FindById(int id)
        {
            return operativeSystemRepository.FindById(id);
        }

        public OperativeSystemM Save(OperativeSystemM OS)
        {
            return operativeSystemRepository.Save(OS);
        }
    }
}
