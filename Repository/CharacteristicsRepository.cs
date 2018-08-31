using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CharacteristicsRepository : ICharacteristicsRepository
    {
        private readonly MobileShopEntities Context;

        public CharacteristicsRepository()
        {
            Context = new MobileShopEntities();
        }

        public CharacteristicsM Delete(int id)
        {
            Characteristic chars = Context.Characteristics.SingleOrDefault(x => x.Id == id);
            Context.Characteristics.Remove(chars);
            Context.SaveChanges();

            return new CharacteristicsM()
            {
                Id = chars.Id,
                PhoneWeight = chars.PhoneWeight,
                Dimensions = chars.Dimensions,
                DualSIM = chars.DualSIM ?? false, 
                SIM = chars.SIM,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CharacteristicsM Edit(CharacteristicsM chars)
        {
            var found = Context.Characteristics.SingleOrDefault(x => x.Id == chars.Id);
            if (found == null)
            {
                return null;
            }
            found.DualSIM = chars.DualSIM;
            found.Dimensions = chars.Dimensions;
            found.SIM = chars.SIM;
            found.PhoneWeight = chars.PhoneWeight;
            Context.SaveChanges();

            return chars;
        }

        public IEnumerable<CharacteristicsM> FindAll()
        {
            List<CharacteristicsM> retVal = new List<CharacteristicsM>();
            foreach (Characteristic chars in Context.Characteristics.ToList())
            {
                retVal.Add(new CharacteristicsM()
                {
                    Id = chars.Id,
                    PhoneWeight = chars.PhoneWeight,
                    Dimensions = chars.Dimensions,
                    DualSIM = chars.DualSIM ?? false,
                    SIM = chars.SIM,
                });
            }

            return retVal;
        }

        public CharacteristicsM FindById(int id)
        {
            Characteristic chars = Context.Characteristics.SingleOrDefault(x => x.Id == id);

            return new CharacteristicsM()
            {
                Id = chars.Id,
                PhoneWeight = chars.PhoneWeight,
                Dimensions = chars.Dimensions,
                DualSIM = chars.DualSIM ?? false,
                SIM = chars.SIM,
            };
        }

        public CharacteristicsM Save(CharacteristicsM chars)
        {
            Characteristic charsDb = new Characteristic()
            {
                PhoneWeight = chars.PhoneWeight,
                Dimensions = chars.Dimensions,
                DualSIM = chars.DualSIM,
                SIM = chars.SIM,
            };
            Context.Characteristics.Add(charsDb);
            Context.SaveChanges();
            chars.Id = charsDb.Id;
            return chars;
        }
    }
}
