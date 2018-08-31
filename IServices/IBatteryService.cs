﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IBatteryService : IService
    {
        IEnumerable<BatteryM> FindAll();
        BatteryM FindById(int id);
        BatteryM Save(BatteryM battery);
        BatteryM Delete(int id);
        BatteryM Edit(BatteryM battery);
    }
}
