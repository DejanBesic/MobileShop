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
    public class CharacteristicsService : ICharacteristicsService
    {
        private readonly CharacteristicsRepository characteristicsRepository;

        public CharacteristicsService()
        {
            characteristicsRepository = new CharacteristicsRepository();
        }

        public CharacteristicsM Delete(int id)
        {
            return characteristicsRepository.Delete(id);
        }

        public CharacteristicsM Edit(CharacteristicsM chars)
        {
            return characteristicsRepository.Edit(chars);
        }

        public IEnumerable<CharacteristicsM> FindAll()
        {
            return characteristicsRepository.FindAll();
        }

        public CharacteristicsM FindById(int id)
        {
            return characteristicsRepository.FindById(id);
        }

        public CharacteristicsM Save(CharacteristicsM chars)
        {
            return characteristicsRepository.Save(chars);
        }
    }
}
