using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommunicationRepository : ICommunicationRepository
    {
        private readonly MobileShopEntities Context;

        public CommunicationRepository()
        {
            Context = new MobileShopEntities();
        }

        public CommunicationM Delete(int id)
        {
            Communication comm = Context.Communications.SingleOrDefault(x => x.Id == id);
            Context.Communications.Remove(comm);
            Context.SaveChanges();

            return new CommunicationM()
            {
                Id = comm.Id,
                DataTransfer = comm.DataTransfer,
                Network2G = comm.Network2G,
                Network3G = comm.Network3G,
                Network4G = comm.Network4G,
                USB = comm.USB,
                WiFi = comm.WiFi,
                Bluetooth = comm.Bluetooth,
                NFC = comm.NFC ?? false,
                GPS = comm.GPS ?? false,
                PhoneMessages = comm.PhoneMessages
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CommunicationM Edit(CommunicationM comm)
        {
            var found = Context.Communications.SingleOrDefault(x => x.Id == comm.Id);
            if (found == null)
            {
                return null;
            }
            found.DataTransfer = comm.DataTransfer;
            found.Network2G = comm.Network2G;
            found.Network3G = comm.Network3G;
            found.Network4G = comm.Network4G;
            found.USB = comm.USB;
            found.WiFi = comm.WiFi;
            found.Bluetooth = comm.Bluetooth;
            found.NFC = comm.NFC;
            found.GPS = comm.GPS;
            found.PhoneMessages = comm.PhoneMessages;
            Context.SaveChanges();

            return comm;
        }

        public IEnumerable<CommunicationM> FindAll()
        {
            List<CommunicationM> retVal = new List<CommunicationM>();
            foreach (Communication comm in Context.Communications.ToList())
            {
                retVal.Add(new CommunicationM()
                {
                    Id = comm.Id,
                    DataTransfer = comm.DataTransfer,
                    Network2G = comm.Network2G,
                    Network3G = comm.Network3G,
                    Network4G = comm.Network4G,
                    USB = comm.USB,
                    WiFi = comm.WiFi,
                    Bluetooth = comm.Bluetooth,
                    NFC = comm.NFC ?? false,
                    GPS = comm.GPS ?? false,
                    PhoneMessages = comm.PhoneMessages
                });
            }

            return retVal;
        }

        public CommunicationM FindById(int id)
        {
            Communication comm = Context.Communications.SingleOrDefault(x => x.Id == id);

            return new CommunicationM()
            {
                Id = comm.Id,
                DataTransfer = comm.DataTransfer,
                Network2G = comm.Network2G,
                Network3G = comm.Network3G,
                Network4G = comm.Network4G,
                USB = comm.USB,
                WiFi = comm.WiFi,
                Bluetooth = comm.Bluetooth,
                NFC = comm.NFC ?? false,
                GPS = comm.GPS ?? false,
                PhoneMessages = comm.PhoneMessages
            };
        }

        public CommunicationM Save(CommunicationM comm)
        {
            Communication commDb = new Communication()
            {
                Id = comm.Id,
                DataTransfer = comm.DataTransfer,
                Network2G = comm.Network2G,
                Network3G = comm.Network3G,
                Network4G = comm.Network4G,
                USB = comm.USB,
                WiFi = comm.WiFi,
                Bluetooth = comm.Bluetooth,
                NFC = comm.NFC,
                GPS = comm.GPS,
                PhoneMessages = comm.PhoneMessages
            };
            Context.Communications.Add(commDb);
            Context.SaveChanges();
            comm.Id = commDb.Id;
            return comm;
        }
    }
}
