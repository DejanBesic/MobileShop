﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMobileRepository : IDisposable
    {
        IEnumerable<MobileM> FindAll();
        MobileM FindById(int id);
        MobileM Save(MobileM mobile);
        MobileM Delete(int id);
        MobileM Edit(MobileM mobile);
    }
}
