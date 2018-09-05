using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BatteryRepository : IBatteryRepository
    {
        private readonly MobileShopEntities Context;

        public BatteryRepository()
        {
            Context = new MobileShopEntities();
        }

        public BatteryM Delete(int id)
        {
            Battery batt = Context.Batteries.SingleOrDefault(x => x.Id == id);
            Context.Batteries.Remove(batt);
            Context.SaveChanges();

            return new BatteryM()
            {
                Id = batt.Id,
                Capacity = batt.Capacity
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public BatteryM Edit(BatteryM battery)
        {
            var found = Context.Batteries.SingleOrDefault(x => x.Id == battery.Id);
            if (found == null)
            {
                return null;
            }
            found.Capacity = battery.Capacity;
            Context.SaveChanges();

            return battery;
        }

        public IEnumerable<BatteryM> FindAll()
        {
            List<BatteryM> retVal = new List<BatteryM>();
            foreach (Battery b in Context.Batteries.ToList())
            {
                retVal.Add(new BatteryM() { Id = b.Id, Capacity = b.Capacity });
            }

            return retVal;
        }

        public BatteryM FindById(int id)
        {
            Battery battery = Context.Batteries.SingleOrDefault(x => x.Id == id);

            return new BatteryM() { Id = battery.Id, Capacity = battery.Capacity };

        }

        public BatteryM Save(BatteryM battery)
        {
            Battery batteryDb = new Battery()
            {
                Capacity = battery.Capacity
            };
            batteryDb = Context.Batteries.Add(batteryDb);
            Context.SaveChanges();
            battery.Id = batteryDb.Id;
            return battery;
        }
    }
}
