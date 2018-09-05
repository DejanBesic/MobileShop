﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICameraMPRepository : IDisposable
    {
        IEnumerable<CameraMPM> FindAll();
        CameraMPM FindById(int id);
        CameraMPM Save(CameraMPM mp);
        CameraMPM Delete(int id);
        CameraMPM Edit(CameraMPM mp);
    }
}
