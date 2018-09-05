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
    public class CamCharsService : ICamCharsService
    {
        private readonly CamCharsRepository charsRepository;

        public CamCharsService()
        {
            charsRepository = new CamCharsRepository();
        }

        public CameraCharacteristicsM Delete(int id)
        {
            return charsRepository.Delete(id);
        }

        public CameraCharacteristicsM Edit(CameraCharacteristicsM chars)
        {
            return charsRepository.Edit(chars);
        }

        public IEnumerable<CameraCharacteristicsM> FindAll()
        {
            return charsRepository.FindAll();
        }

        public CameraCharacteristicsM FindById(int id)
        {
            return charsRepository.FindById(id);
        }

        public CameraCharacteristicsM Save(CameraCharacteristicsM chars)
        {
            return charsRepository.Save(chars);
        }
    }
}
