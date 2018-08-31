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
    public class BatteryService : IBatteryService
    {
        private readonly BatteryRepository batteryRepository;

        public BatteryService()
        {
            batteryRepository = new BatteryRepository();
        }

        public BatteryM Delete(int id)
        {
            return batteryRepository.Delete(id);
        }

        public BatteryM Edit(BatteryM battery)
        {
            return batteryRepository.Edit(battery);
        }

        public IEnumerable<BatteryM> FindAll()
        {
            return batteryRepository.FindAll();
        }

        public BatteryM FindById(int id)
        {
            return batteryRepository.FindById(id);
        }

        public BatteryM Save(BatteryM battery)
        {
            return batteryRepository.Save(battery);
        }
    }
}
