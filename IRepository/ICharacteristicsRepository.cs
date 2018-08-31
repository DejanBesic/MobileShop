using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICharacteristicsRepository : IDisposable
    {
        IEnumerable<CharacteristicsM> FindAll();
        CharacteristicsM FindById(int id);
        CharacteristicsM Save(CharacteristicsM chars);
        CharacteristicsM Delete(int id);
        CharacteristicsM Edit(CharacteristicsM chars);
    }
}
