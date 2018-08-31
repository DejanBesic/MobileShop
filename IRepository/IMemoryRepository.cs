﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMemoryRepository : IDisposable
    {
        IEnumerable<MemoryM> FindAll();
        MemoryM FindById(int id);
        MemoryM Save(MemoryM memory);
        MemoryM Delete(int id);
        MemoryM Edit(MemoryM memory);
    }
}
