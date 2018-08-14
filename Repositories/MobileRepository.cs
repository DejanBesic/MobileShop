using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IRepositories;

namespace Repositories
{
    public class MobileRepository : IMobileRepository
    {
        MobileShopEntities mobiles = new MobileShopEntities();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<DMobile> FindAll()
        {
            List<DMobile> retVal = new List<DMobile>();
            foreach(Mobile m in mobiles.Mobiles.ToList())
            {
                retVal.Add(new DMobile(m.Id, m.Name, m.Model));
            }

           return retVal;
        }

        public DMobile FindById(int id)
        {
            Mobile mobile = mobiles.Mobiles.Single(x => x.Id == id);

            return new DMobile(mobile.Id, mobile.Name, mobile.Model);
        }

        public DMobile Save(DMobile mobile)
        {
            Mobile mobileDB = new Mobile()
            {
                Id = mobile.Id,
                Name = mobile.Name,
                Model = mobile.Model
            };
            mobiles.Entry(mobileDB);
            mobiles.SaveChanges();
            return mobile;
        }
    }
}
