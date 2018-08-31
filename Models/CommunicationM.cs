using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CommunicationM
    {
        public int Id { get; set; }

        public string DataTransfer { get; set; }

        public string USB { get; set; }

        public string Network2G { get; set; }

        public string Network3G { get; set; }

        public string Network4G { get; set; }

        public string WiFi { get; set; }

        public string Bluetooth { get; set; }

        public bool NFC { get; set; }

        public bool GPS { get; set; }

        public string PhoneMessages { get; set; }

        public CommunicationM()
        {

        }
    }
}
