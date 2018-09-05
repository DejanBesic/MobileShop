using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class CamCharsRepository : ICamCharsRepository
    {
        private readonly MobileShopEntities Context;

        public CamCharsRepository()
        {
            Context = new MobileShopEntities();
        }

        public CameraCharacteristicsM Delete(int id)
        {
            CameraCharacteristic chars = Context.CameraCharacteristics.SingleOrDefault(x => x.Id == id);
            Context.CameraCharacteristics.Remove(chars);
            Context.SaveChanges();

            return new CameraCharacteristicsM()
            {
                CamChars = chars.CamChars,
                Id = chars.Id
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CameraCharacteristicsM Edit(CameraCharacteristicsM chars)
        {
            var found = Context.CameraCharacteristics.SingleOrDefault(x => x.Id == chars.Id);
            if (found == null)
            {
                return null;
            }
            found.CamChars = chars.CamChars;
            Context.SaveChanges();

            return chars;
        }

        public IEnumerable<CameraCharacteristicsM> FindAll()
        {
            List<CameraCharacteristicsM> retVal = new List<CameraCharacteristicsM>();
            foreach (CameraCharacteristic b in Context.CameraCharacteristics.ToList())
            {
                retVal.Add(new CameraCharacteristicsM() { Id = b.Id, CamChars = b.CamChars });
            }

            return retVal;
        }

        public CameraCharacteristicsM FindById(int id)
        {
            CameraCharacteristic chars = Context.CameraCharacteristics.SingleOrDefault(x => x.Id == id);

            return new CameraCharacteristicsM() { Id = chars.Id, CamChars = chars.CamChars};
        }

        public CameraCharacteristicsM Save(CameraCharacteristicsM chars)
        {
            CameraCharacteristic charsDb = new CameraCharacteristic()
            {
                CamChars = chars.CamChars
            };
            charsDb = Context.CameraCharacteristics.Add(charsDb);
            Context.SaveChanges();
            chars.Id = charsDb.Id;
            return chars;
        }
    }
}
