using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class DropDowns
    {
        public IEnumerable<AdditionalM> Additionals { get; set; }

        public IEnumerable<BatteryM> Batteries { get; set; }

        public IEnumerable<CameraM> Cameras { get; set; }

        public IEnumerable<CharacteristicsM> Characteristics { get; set; }

        public IEnumerable<CommunicationM> Communications { get; set; }

        public IEnumerable<MemoryM> Memories { get; set; }

        public IEnumerable<PackageContentM> PackageContents { get; set; }

        public IEnumerable<ScreenM> Screens { get; set; }

        public IEnumerable<SoundM> Sounds { get; set; }

        public IEnumerable<ShopM> Shops { get; set; }

        public DropDowns()
        {

        }
    }
}