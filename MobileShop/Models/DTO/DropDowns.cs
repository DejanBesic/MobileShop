﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class DropDowns
    {
        public IEnumerable<BatteryM> Batteries { get; set; }

        public IEnumerable<MemoryM> Memories { get; set; }

        public IEnumerable<CameraM> Cameras { get; set; }

        public IEnumerable<ShopM> Shops { get; set; }

        public IEnumerable<OperativeSystemM> OperativeSystems { get; set; }

        public IEnumerable<RamM> Rams { get; set; }

        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }


        public DropDowns()
        {

        }
    }
}