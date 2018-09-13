using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.DTO
{
    public class OneMobile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string SIM { get; set; }

        public bool DualSIM { get; set; }

        public string Dimensions { get; set; }

        public string PhoneWeight { get; set; }

        public string PackageContent { get; set; }

        public string ScreenSize { get; set; }

        public string Resolution { get; set; }

        public string ScreenType { get; set; }

        public string DataTransfer { get; set; }

        public string Network2G { get; set; }

        public string Network3G { get; set; }

        public string Network4G { get; set; }

        public string FrontCameraChar { get; set; }

        public string BackCameraChar { get; set; }

        public string USB { get; set; }

        public string WiFi { get; set; }

        public string Bluetooth { get; set; }

        public bool NFC { get; set; }

        public bool GPS { get; set; }

        public string PhoneMessages { get; set; }

        public string AdditionalDescription { get; set; }

        public string Video { get; set; }

        public bool Touch { get; set; }

        public bool FMRadio { get; set; }

        public bool Port35mm { get; set; }

        public bool HDVoice { get; set; }

        public string BatteryCapacity { get; set; }

        public string RAM { get; set; }

        public string OperatingSystem { get; set; }

        public string Proccessor { get; set; }

        public string ExternMemory { get; set; }

        public string InternMemory { get; set; }

        public string FrontCamera { get; set; }

        public string BackCamera { get; set; }

        public ShopM Shop { get; set; }

        public double Price { get; set; }

        public IEnumerable<string> Images { get; set; }

    }
}