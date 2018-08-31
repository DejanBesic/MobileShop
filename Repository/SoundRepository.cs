using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SoundRepository : ISoundRepository
    {
        private readonly MobileShopEntities Context;

        public SoundRepository()
        {
            Context = new MobileShopEntities();
        }

        public SoundM Delete(int id)
        {
            Sound sound = Context.Sounds.SingleOrDefault(x => x.Id == id);
            Context.Sounds.Remove(sound);
            Context.SaveChanges();

            return new SoundM()
            {
                Id = sound.Id,
                FMRadio = sound.FMRadio ?? false,
                HDVoice = sound.HDVoice ?? false,
                Port35mm = sound.Port35mm ?? false,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public SoundM Edit(SoundM sound)
        {
            var found = Context.Sounds.SingleOrDefault(x => x.Id == sound.Id);
            if (found == null)
            {
                return null;
            }
            found.FMRadio = sound.FMRadio;
            found.HDVoice = sound.HDVoice;
            found.Port35mm = sound.Port35mm;
            Context.SaveChanges();

            return sound;
        }

        public IEnumerable<SoundM> FindAll()
        {
            List<SoundM> retVal = new List<SoundM>();
            foreach (Sound sound in Context.Sounds.ToList())
            {
                retVal.Add(new SoundM()
                {
                    Id = sound.Id,
                    FMRadio = sound.FMRadio ?? false,
                    HDVoice = sound.HDVoice ?? false,
                    Port35mm = sound.Port35mm ?? false,
                });
            }

            return retVal;
        }

        public SoundM FindById(int id)
        {
            Sound sound = Context.Sounds.SingleOrDefault(x => x.Id == id);

            return new SoundM()
            {
                Id = sound.Id,
                FMRadio = sound.FMRadio ?? false,
                HDVoice = sound.HDVoice ?? false,
                Port35mm = sound.Port35mm ?? false,
            };
        }

        public SoundM Save(SoundM sound)
        {
            Sound soundDb = new Sound()
            {
                FMRadio = sound.FMRadio,
                HDVoice = sound.HDVoice,
                Port35mm = sound.Port35mm,
            };
            Context.Sounds.Add(soundDb);
            Context.SaveChanges();
            sound.Id = soundDb.Id;
            return sound;
        }
    }
}

