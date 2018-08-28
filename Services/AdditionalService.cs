using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using Models;
using Repository;

namespace Services
{
    public class AdditionalService : IAdditionalService
    {
        private readonly AdditionalRepository additionalRepository = new AdditionalRepository();

        public IEnumerable<AdditionalM> FindAll()
        {
            return additionalRepository.FindAll();
        }

        public AdditionalM FindById(int id)
        {
            return additionalRepository.FindById(id);
        }

        public AdditionalM Save(AdditionalM additional)
        {
            return additionalRepository.Save(additional);
        }

        public AdditionalM Delete(int id)
        {
            return additionalRepository.Delete(id);
        }

        public AdditionalM Edit(AdditionalM additional)
        {
            return additionalRepository.Edit(additional);
        }
    }
}
