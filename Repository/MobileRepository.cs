using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MobileRepository : IMobileRepository
    {
        private readonly MobileShopEntities Context;

        public MobileRepository()
        {
            Context = new MobileShopEntities();
        }

        public MobileM Delete(int id)
        {
            Mobile mobile = Context.Mobiles.SingleOrDefault(x => x.Id == id);
            Context.Mobiles.Remove(mobile);
            Context.SaveChanges();

            return new MobileM()
            {
                Id = mobile.Id,
                Name = mobile.MobileName,
                About = mobile.About,
                BatteryId = mobile.BatteryId ?? -1,
                BackCameraId = mobile.BackCameraId ?? -1,
                ExternMemoryId = mobile.ExternMemoryId ?? -1,
                InternMemoryId = mobile.InternMemoryId ?? -1,
                FrontCameraId = mobile.FrontCameraId ?? -1,
                OsId = mobile.OsId ?? -1,
                Proccessor = mobile.Proccessor,
                RamId = mobile.RamId ?? -1,
                AdditionalDescription = mobile.AdditionalDescription,
                BackCameraChar = mobile.BackCameraChar,
                Bluetooth = mobile.Bluetooth,
                DataTransfer = mobile.DataTransfer,
                Dimensions = mobile.Dimensions,
                DualSIM = mobile.DualSIM ?? false,
                FMRadio = mobile.FMRadio ?? false,
                FrontCameraChar = mobile.FrontCameraChar,
                GPS = mobile.GPS ?? false,
                HDVoice  = mobile.HDVoice ?? false,
                Network2G = mobile.Network2G,
                Network3G = mobile.Network3G,
                Network4G = mobile.Network4G,
                NFC = mobile.NFC ?? false,
                PackageContent = mobile.PackageContent,
                PhoneMessages = mobile.PhoneMessages,
                PhoneWeight = mobile.PhoneWeight,
                Port35mm = mobile.Port35mm ?? false,
                Resolution = mobile.Resolution,
                ScreenSize = mobile.Size,
                ScreenType = mobile.ScreenType,
                SIM = mobile.SIM,
                Touch = mobile.Touch ?? false,
                USB = mobile.USB,
                Video = mobile.Video, 
                WiFi = mobile.WiFi,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MobileM Edit(MobileM mobile)
        {
            var found = Context.Mobiles.SingleOrDefault(x => x.Id == mobile.Id);
            if (found == null)
            {
                return null;
            }
            found.About = mobile.About;
            found.MobileName = mobile.Name;
            found.BatteryId = mobile.BatteryId;
            found.BackCameraId = mobile.BackCameraId;
            found.ExternMemoryId = mobile.ExternMemoryId;
            found.InternMemoryId = mobile.InternMemoryId;
            found.FrontCameraId = mobile.FrontCameraId;
            found.OsId = mobile.OsId;
            found.Proccessor = mobile.Proccessor;
            found.RamId = mobile.RamId;
            found.AdditionalDescription = mobile.AdditionalDescription;
            found.BackCameraChar = mobile.BackCameraChar;
            found.Bluetooth = mobile.Bluetooth;
            found.DataTransfer = mobile.DataTransfer;
            found.Dimensions = mobile.Dimensions;
            found.DualSIM = mobile.DualSIM;
            found.FMRadio = mobile.FMRadio;
            found.FrontCameraChar = mobile.FrontCameraChar;
            found.GPS = mobile.GPS;
            found.HDVoice = mobile.HDVoice;
            found.Network2G = mobile.Network2G;
            found.Network3G = mobile.Network3G;
            found.Network4G = mobile.Network4G;
            found.NFC = mobile.NFC;
            found.PackageContent = mobile.PackageContent;
            found.PhoneMessages = mobile.PhoneMessages;
            found.PhoneWeight = mobile.PhoneWeight;
            found.Port35mm = mobile.Port35mm;
            found.Resolution = mobile.Resolution;
            found.Size = mobile.ScreenSize;
            found.ScreenType = mobile.ScreenType;
            found.SIM = mobile.SIM;
            found.Touch = mobile.Touch;
            found.USB = mobile.USB;
            found.Video = mobile.Video;
            found.WiFi = mobile.WiFi;
            Context.SaveChanges();

            return mobile;
        }

        public IEnumerable<MobileM> FindAll()
        {
            List<MobileM> retVal = new List<MobileM>();
            foreach (Mobile mobile in Context.Mobiles.ToList())
            {
                retVal.Add(new MobileM()
                {
                    Id = mobile.Id,
                    Name = mobile.MobileName,
                    About = mobile.About,
                    BatteryId = mobile.BatteryId ?? -1,
                    BackCameraId = mobile.BackCameraId ?? -1,
                    ExternMemoryId = mobile.ExternMemoryId ?? -1,
                    InternMemoryId = mobile.InternMemoryId ?? -1,
                    FrontCameraId = mobile.FrontCameraId ?? -1,
                    OsId = mobile.OsId ?? -1,
                    Proccessor = mobile.Proccessor,
                    RamId = mobile.RamId ?? -1,
                    AdditionalDescription = mobile.AdditionalDescription,
                    BackCameraChar = mobile.BackCameraChar,
                    Bluetooth = mobile.Bluetooth,
                    DataTransfer = mobile.DataTransfer,
                    Dimensions = mobile.Dimensions,
                    DualSIM = mobile.DualSIM ?? false,
                    FMRadio = mobile.FMRadio ?? false,
                    FrontCameraChar = mobile.FrontCameraChar,
                    GPS = mobile.GPS ?? false,
                    HDVoice = mobile.HDVoice ?? false,
                    Network2G = mobile.Network2G,
                    Network3G = mobile.Network3G,
                    Network4G = mobile.Network4G,
                    NFC = mobile.NFC ?? false,
                    PackageContent = mobile.PackageContent,
                    PhoneMessages = mobile.PhoneMessages,
                    PhoneWeight = mobile.PhoneWeight,
                    Port35mm = mobile.Port35mm ?? false,
                    Resolution = mobile.Resolution,
                    ScreenSize = mobile.Size,
                    ScreenType = mobile.ScreenType,
                    SIM = mobile.SIM,
                    Touch = mobile.Touch ?? false,
                    USB = mobile.USB,
                    Video = mobile.Video,
                    WiFi = mobile.WiFi,
                });
            }

            return retVal;
        }

        public MobileM FindById(int id)
        {
            Mobile mobile = Context.Mobiles.SingleOrDefault(x => x.Id == id);

            if (mobile == null)
            {
                return null;
            }

            return new MobileM()
            {
                Id = mobile.Id,
                Name = mobile.MobileName,
                About = mobile.About,
                BatteryId = mobile.BatteryId ?? -1,
                BackCameraId = mobile.BackCameraId ?? -1,
                ExternMemoryId = mobile.ExternMemoryId ?? -1,
                InternMemoryId = mobile.InternMemoryId ?? -1,
                FrontCameraId = mobile.FrontCameraId ?? -1,
                OsId = mobile.OsId ?? -1,
                Proccessor = mobile.Proccessor,
                RamId = mobile.RamId ?? -1,
                AdditionalDescription = mobile.AdditionalDescription,
                BackCameraChar = mobile.BackCameraChar,
                Bluetooth = mobile.Bluetooth,
                DataTransfer = mobile.DataTransfer,
                Dimensions = mobile.Dimensions,
                DualSIM = mobile.DualSIM ?? false,
                FMRadio = mobile.FMRadio ?? false,
                FrontCameraChar = mobile.FrontCameraChar,
                GPS = mobile.GPS ?? false,
                HDVoice = mobile.HDVoice ?? false,
                Network2G = mobile.Network2G,
                Network3G = mobile.Network3G,
                Network4G = mobile.Network4G,
                NFC = mobile.NFC ?? false,
                PackageContent = mobile.PackageContent,
                PhoneMessages = mobile.PhoneMessages,
                PhoneWeight = mobile.PhoneWeight,
                Port35mm = mobile.Port35mm ?? false,
                Resolution = mobile.Resolution,
                ScreenSize = mobile.Size,
                ScreenType = mobile.ScreenType,
                SIM = mobile.SIM,
                Touch = mobile.Touch ?? false,
                USB = mobile.USB,
                Video = mobile.Video,
                WiFi = mobile.WiFi,
            };
        }

        public MobileM Save(MobileM mobile)
        {
            Mobile mobileDb = new Mobile()
            {
                Id = mobile.Id,
                MobileName = mobile.Name,
                About = mobile.About,
                BatteryId = mobile.BatteryId,
                BackCameraId = mobile.BackCameraId,
                ExternMemoryId = mobile.ExternMemoryId,
                InternMemoryId = mobile.InternMemoryId,
                FrontCameraId = mobile.FrontCameraId,
                OsId = mobile.OsId,
                Proccessor = mobile.Proccessor,
                RamId = mobile.RamId,
                AdditionalDescription = mobile.AdditionalDescription,
                BackCameraChar = mobile.BackCameraChar,
                Bluetooth = mobile.Bluetooth,
                DataTransfer = mobile.DataTransfer,
                Dimensions = mobile.Dimensions,
                DualSIM = mobile.DualSIM,
                FMRadio = mobile.FMRadio,
                FrontCameraChar = mobile.FrontCameraChar,
                GPS = mobile.GPS,
                HDVoice = mobile.HDVoice,
                Network2G = mobile.Network2G,
                Network3G = mobile.Network3G,
                Network4G = mobile.Network4G,
                NFC = mobile.NFC,
                PackageContent = mobile.PackageContent,
                PhoneMessages = mobile.PhoneMessages,
                PhoneWeight = mobile.PhoneWeight,
                Port35mm = mobile.Port35mm,
                Resolution = mobile.Resolution,
                Size = mobile.ScreenSize,
                ScreenType = mobile.ScreenType,
                SIM = mobile.SIM,
                Touch = mobile.Touch,
                USB = mobile.USB,
                Video = mobile.Video,
                WiFi = mobile.WiFi,
            };
            Context.Mobiles.Add(mobileDb);
            Context.SaveChanges();
            mobile.Id = mobileDb.Id;
            return mobile;
        }
    }
}
