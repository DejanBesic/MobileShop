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
                About = mobile.About,
                AdditionalId = mobile.AdditionalId ?? -1,
                BatteryId = mobile.BatteryId ?? -1,
                CharacteristicsId = mobile.CharacteristicsId ?? -1,
                CommunicationId = mobile.CommunicationId ?? -1,
                PackageContentId = mobile.PackageContentId ?? -1,
                Price = mobile.Price ?? 0,
                ScreenId = mobile.ScreenId ?? -1,
                SoundId = mobile.SoundId ?? -1,
                BackCameraId = mobile.BackCameraId ?? -1,
                ExternMemoryId = mobile.ExternMemoryId ?? -1,
                InternMemoryId = mobile.InternMemoryId ?? -1,
                FrontCameraId = mobile.FrontCameraId ?? -1,
                OsId = mobile.OsId ?? -1,
                ProcessorId = mobile.ProccessorId ?? -1,
                RamId = mobile.RamId ?? -1,
                VideoId = mobile.VideoId ?? -1
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
            found.AdditionalId = mobile.AdditionalId;
            found.BatteryId = mobile.BatteryId;
            found.CharacteristicsId = mobile.CharacteristicsId;
            found.CommunicationId = mobile.CommunicationId;
            found.PackageContentId = mobile.PackageContentId;
            found.Price = mobile.Price;
            found.ScreenId = mobile.ScreenId;
            found.SoundId = mobile.SoundId;
            found.BackCameraId = mobile.BackCameraId;
            found.ExternMemoryId = mobile.ExternMemoryId;
            found.InternMemoryId = mobile.InternMemoryId;
            found.FrontCameraId = mobile.FrontCameraId;
            found.OsId = mobile.OsId;
            found.ProccessorId = mobile.ProcessorId;
            found.RamId = mobile.RamId;
            found.VideoId = mobile.VideoId;
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
                    About = mobile.About,
                    AdditionalId = mobile.AdditionalId ?? -1,
                    BatteryId = mobile.BatteryId ?? -1,
                    CharacteristicsId = mobile.CharacteristicsId ?? -1,
                    CommunicationId = mobile.CommunicationId ?? -1,
                    PackageContentId = mobile.PackageContentId ?? -1,
                    Price = mobile.Price ?? 0,
                    ScreenId = mobile.ScreenId ?? -1,
                    SoundId = mobile.SoundId ?? -1,
                    BackCameraId = mobile.BackCameraId ?? -1,
                    ExternMemoryId = mobile.ExternMemoryId ?? -1,
                    InternMemoryId = mobile.InternMemoryId ?? -1,
                    FrontCameraId = mobile.FrontCameraId ?? -1,
                    OsId = mobile.OsId ?? -1,
                    ProcessorId = mobile.ProccessorId ?? -1,
                    RamId = mobile.RamId ?? -1,
                    VideoId = mobile.VideoId ?? -1
                });
            }

            return retVal;
        }

        public MobileM FindById(int id)
        {
            Mobile mobile = Context.Mobiles.SingleOrDefault(x => x.Id == id);

            return new MobileM()
            {
                Id = mobile.Id,
                About = mobile.About,
                AdditionalId = mobile.AdditionalId ?? -1,
                BatteryId = mobile.BatteryId ?? -1,
                CharacteristicsId = mobile.CharacteristicsId ?? -1,
                CommunicationId = mobile.CommunicationId ?? -1,
                PackageContentId = mobile.PackageContentId ?? -1,
                Price = mobile.Price ?? 0,
                ScreenId = mobile.ScreenId ?? -1,
                SoundId = mobile.SoundId ?? -1,
                BackCameraId = mobile.BackCameraId ?? -1,
                ExternMemoryId = mobile.ExternMemoryId ?? -1,
                InternMemoryId = mobile.InternMemoryId ?? -1,
                FrontCameraId = mobile.FrontCameraId ?? -1,
                OsId = mobile.OsId ?? -1,
                ProcessorId = mobile.ProccessorId ?? -1,
                RamId = mobile.RamId ?? -1,
                VideoId = mobile.VideoId ?? -1
            };
        }

        public MobileM Save(MobileM mobile)
        {
            Mobile mobileDb = new Mobile()
            {
                About = mobile.About,
                AdditionalId = mobile.AdditionalId,
                BatteryId = mobile.BatteryId,
                CharacteristicsId = mobile.CharacteristicsId,
                CommunicationId = mobile.CommunicationId,
                PackageContentId = mobile.PackageContentId,
                Price = mobile.Price,
                ScreenId = mobile.ScreenId,
                SoundId = mobile.SoundId,
                BackCameraId = mobile.BackCameraId,
                ExternMemoryId = mobile.ExternMemoryId,
                InternMemoryId = mobile.InternMemoryId,
                FrontCameraId = mobile.FrontCameraId,
                OsId = mobile.OsId,
                ProccessorId = mobile.ProcessorId,
                RamId = mobile.RamId,
                VideoId = mobile.VideoId
            };
            Context.Mobiles.Add(mobileDb);
            Context.SaveChanges();
            mobile.Id = mobileDb.Id;
            return mobile;
        }
    }
}
