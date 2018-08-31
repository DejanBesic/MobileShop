using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICharacteristicsService : IService
    {
        IEnumerable<CharacteristicsM> FindAll();
        CharacteristicsM FindById(int id);
        CharacteristicsM Save(CharacteristicsM chars);
        CharacteristicsM Delete(int id);
        CharacteristicsM Edit(CharacteristicsM chars);
    }
}
