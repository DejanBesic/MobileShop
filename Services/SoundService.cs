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
    public class SoundService : ISoundService
    {
        private readonly SoundRepository soundRepository;

        public SoundService()
        {
            soundRepository = new SoundRepository();
        }

        public SoundM Delete(int id)
        {
            return soundRepository.Delete(id);
        }

        public SoundM Edit(SoundM sound)
        {
            return soundRepository.Edit(sound);
        }

        public IEnumerable<SoundM> FindAll()
        {
            return soundRepository.FindAll();
        }

        public SoundM FindById(int id)
        {
            return soundRepository.FindById(id);
        }

        public SoundM Save(SoundM sound)
        {
            return soundRepository.Save(sound);
        }
    }
}
