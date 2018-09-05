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
    public class CameraMPService : ICameraMPService
    {
        private readonly CameraMPRepository mPRepository;

        public CameraMPService()
        {
            mPRepository = new CameraMPRepository();
        }

        public CameraMPM Delete(int id)
        {
            return mPRepository.Delete(id);
        }

        public CameraMPM Edit(CameraMPM mp)
        {
            return mPRepository.Edit(mp);
        }

        public IEnumerable<CameraMPM> FindAll()
        {
            return mPRepository.FindAll();
        }

        public CameraMPM FindById(int id)
        {
            return mPRepository.FindById(id);
        }

        public CameraMPM Save(CameraMPM mp)
        {
            return mPRepository.Save(mp);
        }
    }
}
